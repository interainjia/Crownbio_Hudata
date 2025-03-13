using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;

namespace Crownbio.Language
{
    /// <summary>
    /// 提供多语言资源集的操作
    /// </summary>
    public class LanguageHelper
    {
        private static ResourceManager rm = null;

        /// <summary>
        /// 返回资源管理器
        /// </summary>
        /// <returns></returns>
        public static ResourceManager GetResourceManager()
        {
            if (rm == null)
            {
                rm = new ResourceManager("Crownbio.Language.Resource_zh-CN", typeof(LanguageHelper).Assembly);
            }
            return rm;
        }

        /// <summary>
        /// 设置资源文件为指定语言的资源文件
        /// </summary>
        /// <param name="lang">语言标识符</param>
        public static void SetResourceManager(string lang)
        {
            try
            {
                rm = new ResourceManager("Crownbio.Language.Resource_" + lang, typeof(LanguageHelper).Assembly);
            }
            catch 
            {
            }
        }

        /// <summary>
        /// 根据Resource Key返回其对应的Text
        /// </summary>
        /// <param name="resourceKeyName"></param>
        /// <returns></returns>
        public static string GetResourceText(string resourceKeyName)
        {
            try
            {
                if (rm == null)
                {
                    GetResourceManager();
                }
                string resourceText = rm.GetString(resourceKeyName);
                if (resourceText == null)
                {
                    return resourceKeyName;
                }
                else
                {
                    return resourceText;
                }
            }
            catch
            {
                return resourceKeyName;
            }
        }
    }
}
