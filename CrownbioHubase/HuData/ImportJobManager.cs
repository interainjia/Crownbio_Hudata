using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Web.Hosting;
using Crownbio.Model;
using Crownbio.Utility;

namespace PDXmodelBase.HuData
{
    /// <summary>
    /// 后台异步导入任务。大文件导入耗时可能超过网关（jump server / nginx）超时，
    /// 因此上传后立即返回任务 ID，导入在后台执行，前端轮询进度。
    /// </summary>
    public class ImportJob
    {
        public string Id { get; set; }
        public string Tablename { get; set; }
        public decimal UserId { get; set; }
        public string UserName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        /// <summary>running / done / failed</summary>
        public string Status { get; set; }
        public string Stage { get; set; }
        public int Processed { get; set; }
        public int Total { get; set; }
        /// <summary>完成或失败后的结果信息（与原同步导入返回的文字一致）</summary>
        public string Message { get; set; }

        public bool IsRunning => Status == "running";

        public void Report(int processed, int total, string stage)
        {
            Processed = processed;
            Total = total;
            if (stage != null) Stage = stage;
        }
    }

    public static class ImportJobManager
    {
        /// <summary>上传请求返回此前缀 + 任务 ID，前端据此进入轮询</summary>
        public const string ResponsePrefix = "ASYNC_JOB:";

        private static readonly ConcurrentDictionary<string, ImportJob> Jobs = new ConcurrentDictionary<string, ImportJob>();
        private static readonly object StartLock = new object();
        private static readonly TimeSpan KeepFinishedJobs = TimeSpan.FromHours(24);

        /// <summary>
        /// 启动后台导入。同一种导入同时只允许一个在运行（避免并发写同一批数据、重复发预警邮件）。
        /// work 返回最终结果信息；抛出异常视为失败。
        /// </summary>
        public static ImportJob TryStart(string tablename, SYS_USER user, Func<ImportJob, string> work, out string error)
        {
            error = null;
            ImportJob job;
            lock (StartLock)
            {
                CleanUp();
                ImportJob running = Jobs.Values.FirstOrDefault(j => j.Tablename == tablename && j.IsRunning);
                if (running != null)
                {
                    error = string.Format("An {0} import started by {1} at {2:yyyy-MM-dd HH:mm} is still running ({3}/{4}). Please wait until it finishes.",
                        tablename, running.UserName, running.StartTime, running.Processed, running.Total);
                    return null;
                }

                job = new ImportJob
                {
                    Id = Guid.NewGuid().ToString("N"),
                    Tablename = tablename,
                    UserId = user?.USER_ID ?? 0,
                    UserName = user?.USER_NAME ?? user?.EMAIL ?? "",
                    StartTime = DateTime.Now,
                    Status = "running",
                    Stage = "Queued"
                };
                Jobs[job.Id] = job;
            }

            HostingEnvironment.QueueBackgroundWorkItem(cancellationToken =>
            {
                CacheHelper.BeginBackground(user);
                try
                {
                    job.Message = work(job);
                    job.Status = "done";
                }
                catch (Exception ex)
                {
                    LogHelper.Log(ex);
                    job.Message = ex.Message;
                    job.Status = "failed";
                }
                finally
                {
                    CacheHelper.EndBackground();
                    job.EndTime = DateTime.Now;
                }
            });
            return job;
        }

        public static ImportJob Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            Jobs.TryGetValue(id, out ImportJob job);
            return job;
        }

        private static void CleanUp()
        {
            foreach (var job in Jobs.Values.Where(j => !j.IsRunning && j.EndTime.HasValue && DateTime.Now - j.EndTime.Value > KeepFinishedJobs).ToList())
            {
                Jobs.TryRemove(job.Id, out _);
            }
        }
    }
}
