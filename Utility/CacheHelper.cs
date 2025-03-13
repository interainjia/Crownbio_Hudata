using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Crownbio.Model;
using Crownbio.Common;
using System.Web.SessionState;
using System.Web;

namespace Crownbio.Utility
{
    /// <summary>
    /// 提供缓存的存取方法
    /// </summary>
    public class CacheHelper
    {
        /// <summary>
        /// 获取缓存资料 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object getCacheData(string keyName)
        {
            HttpSessionState session = HttpContext.Current.Session;
            return session[keyName];

        }

        /// <summary>
        /// 获取缓存资料 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string getPathByKey(string keyName)
        {
            return HttpContext.Current.Server.MapPath(keyName);
        }

        /// <summary>
        /// 设置缓存资料
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void setCacheData(string keyName, Object data)
        {
            HttpSessionState session = HttpContext.Current.Session;
            ///将一个数据装入缓存，无过期时间
            session.Add(keyName, data);
        }

        /// <summary>
        /// 获取当前登录用户的缓存信息
        /// </summary>
        /// <returns></returns>
        public static SYS_USER getCurrentUser()
        {
            HttpSessionState session = HttpContext.Current.Session;
            if (session["HudataUserInfo"] != null)
            //if (HttpContext.Current.Cache["UserInfo"] != null)
            {
                //return (SYS_USER)HttpContext.Current.Cache["UserInfo"];
                return (SYS_USER)session["HudataUserInfo"];
            }
            else
            {
                return new SYS_USER();
            }
            //return null;
            //SYS_USER user = new SYS_USER();
            //user.USER_ID = 1;
            //return user;
        }

        /// <summary>
        /// 获取当前登录用户的缓存信息
        /// </summary>
        /// <returns></returns>
        public static APP_USR getUser()
        {
            HttpSessionState session = HttpContext.Current.Session;
            if (session["UserInfoA"] != null)
            //if (HttpContext.Current.Cache["UserInfo"] != null)
            {
                //return (SYS_USER)HttpContext.Current.Cache["UserInfo"];
                return (APP_USR)session["UserInfoA"];
            }
            else
            {
                return new APP_USR();
            }
            //return null;
            //SYS_USER user = new SYS_USER();
            //user.USER_ID = 1;
            //return user;
        }

        /// <summary>
        /// 返回角色的查询条件
        /// </summary>
        /// <param name="roleField"></param>
        /// <returns></returns>
        //public static string getRoleDataPerm(string roleField)
        //{
        //    string clause = "";
        //    SYS_USER userLogin = getCurrentUser();
        //    if (userLogin.IS_Login)
        //    {
        //        SysUserRoleData userRole = userLogin.Permission;
        //        if (userRole.Tables[0].Rows.Count > 0)
        //        {
        //            clause = "(";
        //            foreach (DataRow dr in userRole.Tables[0].Rows)
        //            {
        //                clause += " ("+roleField + " LIKE '%" + dr[SysUserRoleData.ROLE_NO_FIELD].ToString() + ";%') OR";
        //            }
        //            clause = clause.Substring(0, clause.Length - 2)+")";
        //        }
        //    }
        //    return clause;
        //}

        public static bool CheckPerm()
        {
            bool isPerm = false;
            SYS_USER userLogin = getCurrentUser();
            if (userLogin.IS_Login)
            {
                PermCollection permData = userLogin.Permission;
                string url = HttpContext.Current.Request.Path;
                int offset = url.LastIndexOf("/");
                int offsetEnd = url.LastIndexOf(".");
                string funCode = url.Substring(offset + 1, offsetEnd - offset - 1);

                if (permData.Find(funCode) != null)
                {
                    isPerm = true;
                }


                //DataView dv = new DataView(permData.Tables[0]);
                //dv.RowFilter = String.Format("{0}='{1}'", SysPermData.FUNCTION_NAME_FIELD, funCode);
                //if (dv.Count > 0)
                //{
                //    isPerm = true;
                //}
            }
            return isPerm;
        }
        /// <summary>
        /// 返回项目代号
        /// </summary>
        /// <returns></returns>
        public static string getProjectCode()
        {
            if (getCacheData("PROJECT_CODE") != null)
            {
                return (string)getCacheData("PROJECT_CODE");
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 返回权限类别
        /// </summary>
        /// <returns></returns>
        public static string getRoleType()
        {
            if (getCacheData("ROLE_TYPE") != null)
            {
                return (string)getCacheData("ROLE_TYPE");
            }
            else
            {
                return "";
            }
        }


        /// <summary>
        /// 返回当前物资编码类别
        /// </summary>
        /// <returns></returns>
        public static string getMcsType()
        {
            if (getCacheData("MCS_TYPE") != null)
            {
                return (string)getCacheData("MCS_TYPE");
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回当前费用编码类别
        /// </summary>
        /// <returns></returns>
        public static string getFcsType()
        {
            if (getCacheData("FCS_TYPE") != null)
            {
                return (string)getCacheData("FCS_TYPE");
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回当前费用科目编码类别
        /// </summary>
        /// <returns></returns>
        public static string getFcmType()
        {
            if (getCacheData("FCM_TYPE") != null)
            {
                return (string)getCacheData("FCM_TYPE");
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 返回当前wbs编码类别
        /// </summary>
        /// <returns></returns>
        public static string getWbsType()
        {
            if (getCacheData("WBS_TYPE_CODE") != null)
            {
                return (string)getCacheData("WBS_TYPE_CODE");
            }
            else
            {
                return null;
            }
        }

        public static string getOrganCode()
        {
            if (getCacheData("ORGAN_CODE") != null)
            {
                return (string)getCacheData("ORGAN_CODE");
            }
            else
            {
                return "";
            }
        }

        public static BaseList getDigitData()
        {
            if (getCacheData("DigitData") != null)
            {
                return (BaseList)getCacheData("DigitData");
            }
            else
            {
                return new BaseList();
            }
        }

        //public static bool HasPerm(string functionCode)
        //{
        //    bool _dealPerm = false;
        //    SYS_USER userLogin = getCurrentUser();
        //    if (userLogin.IS_Login)
        //    {
        //    }
        //    if (subForm != null)
        //    {
        //        if (tag != null)
        //        {
        //            if (userLogin.Permission.Find(((SYS_PERM)subForm.Tag).MODULE_CODE + tag.ToString()) != null)
        //            {
        //                _dealPerm = true;//表示存在某操作的操作权限
        //            }
        //        }
        //    }
        //    return _dealPerm;
        //}


    }





    /// <summary>
    /// 提供缓存的存取方法
    /// </summary>
    public class WordCacheHelper
    {
        /// <summary>
        /// 获取缓存资料 
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static object getCacheData(string keyName)
        {
            CacheManager appCaching = CacheFactory.GetCacheManager();
            return appCaching.GetData(keyName);

        }

        /// <summary>
        /// 设置缓存资料
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void setCacheData(string keyName, Object data)
        {
            CacheManager appCaching = CacheFactory.GetCacheManager();
            ///将一个数据装入缓存，无过期时间
            appCaching.Add(keyName, data);
        }

        /// <summary>
        /// 获取当前登录用户的缓存信息
        /// </summary>
        /// <returns></returns>
        public static SYS_USER getCurrentUser()
        {
            if (getCacheData("currentUser") != null)
            {
                return (SYS_USER)getCacheData("currentUser");
            }
            else
            {
                return null;
            }
        }




    }
}
