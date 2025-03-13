using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.IO;
using Crownbio.Common;


namespace Crownbio.Utility
{
    public class FileHelper
    {
        #region 文件的读取和保存(服务器端)
        /// <summary>
        /// 读取文件(文件流)
        /// </summary>
        /// <param name="fileName">目标完整路径</param>
        /// <returns></returns>
        public static byte[] ReadFile(string FilePath, ref string strError)
        {
            if (File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.Open);
                byte[] buffer = new byte[fs.Length];

                try
                {
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Seek(0, SeekOrigin.Begin);
                    return buffer;
                }
                catch
                {
                    return buffer;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
            }
            else
            {
                strError += "文件不存在。\r\n";
                return null;
            }

        }

        /// <summary>
        /// 写入文件(文件流)
        /// </summary>
        /// <param name="pReadByte"></param>
        /// <param name="fileName">目标完整路径</param>
        /// <returns></returns>
        public static bool WriteFile(byte[] pReadByte, string FilePath, ref string strError)
        {
            if (pReadByte != null)
            {
                CheckDirectory(Path.GetDirectoryName(FilePath), true);
                FileStream fs = new FileStream(FilePath, FileMode.OpenOrCreate);
                try
                {
                    fs.Write(pReadByte, 0, pReadByte.Length);
                }
                catch
                {
                    return false;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
                return true;
            }
            else
            {
                //strError += "";
                return false;
            }
        }


        #endregion



        #region 文件的基本操作
        /// <summary>
        /// 空白文档
        /// </summary>
        private static void WordBlank()
        {

        }




        /// <summary>
        /// 复制文件
        /// </summary>
        public static void CopyFile(string sourceFileName, string destFileName, bool overwrite)
        {
            CheckDirectory(Path.GetDirectoryName(destFileName), true);
            File.Copy(sourceFileName, destFileName, overwrite);
        }


        /// <summary>
        /// 删除文档
        /// </summary>
        public static bool DeleteFile(string fileName, ref string strError)
        {
            bool isDeleted = false;
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                    isDeleted = true;
                }
                catch (Exception ex)
                {
                    strError = ex.Message;
                }
            }
            return isDeleted;
        }

        /// <summary>
        /// 删除文档
        /// </summary>
        public static void Delete(string fileName)
        {
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception ex)
                {
                }
            }
        }

        /// <summary>
        /// 删除文件夹和文件
        /// </summary>
        /// <param name="dir">文件夹</param>
        /// <param name="isSelf">是否删除文件夹本身</param>
        public static void DeleteFolder(string dir, bool isSelf)
        {
            if (Directory.Exists(dir))
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    if (File.Exists(f))
                    {
                        FileInfo fi = new FileInfo(f);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        try
                        {
                            File.Delete(f);
                        }
                        catch (Exception ex) { }
                    }
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    DeleteFolder(d, true);
                }
                if (isSelf)
                {
                    DirectoryInfo di = new DirectoryInfo(dir);
                    if (di.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        di.Attributes = FileAttributes.Normal;
                    try
                    {
                        Directory.Delete(dir);
                    }
                    catch (Exception ex) { }
                }
            }
        }

        /// <summary>
        /// 验证文件夹是否存在
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <param name="isCreatDirectory">是否创建文件夹</param>
        public static void CheckDirectory(string directoryPath, bool isCreatDirectory)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            if (!dir.Exists && isCreatDirectory)
                dir.Create();
        }


        #endregion
    }


    public class RandomHelper
    {
        public static string getRandom(int length)
        {
            string result = "";
            int number = 0;
            char code;

            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                result += code.ToString();
            }
            return result;
        }

        /// <summary>
        /// 随机生成条形码
        /// </summary>
        /// <returns>例如:"S-102909211000001-12"</returns>
        public static string getBarCode()
        {
            string result = "";
            int number = 0;
            char code;

            Random random = new Random();
            number = random.Next();
            code = (char)('A' + (char)(number % 26));
            result += code.ToString();

            result += "-";

            for (int i = 0; i < 16; i++)
            {
                number = random.Next();
                code = (char)('0' + (char)(number % 10));
                result += code.ToString();
            }

            result += "-";

            for (int i = 0; i < 2; i++)
            {
                number = random.Next();
                code = (char)('0' + (char)(number % 10));
                result += code.ToString();
            }


            return result;
        }


        /// <summary>
        /// 获取一个随机的文件名
        /// </summary>
        /// <returns></returns>
        public static string getRandomFileName(int length)
        {
            string result = "";
            int number = 0;
            char code;

            Random random = new Random();


            for (int i = 0; i < length; i++)
            {
                number = random.Next();
                if (number % 2 == 0)
                    code = (char)('0' + (char)(number % 10));
                else
                    code = (char)('A' + (char)(number % 26));
                result += code.ToString();
            }

            result += ".doc";

            //for (int i = 0; i < 3; i++)
            //{
            //    number = random.Next();
            //    if (number % 2 == 0)
            //        code = (char)('0' + (char)(number % 10));
            //    else
            //        code = (char)('A' + (char)(number % 26));
            //    result += code.ToString();
            //}


            return result;
        }

        public static string getRandomFileName(int length, string dir)
        {
            string result = getRandomFileName(length);
            if (File.Exists(dir + @"\" + result))
                return getRandomFileName(length, dir);
            return result;
        }
    }

}
