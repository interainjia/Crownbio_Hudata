using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using Crownbio.Common;

namespace Crownbio.Model
{
	/// <summary>
	/// 用户登录信息
	/// </summary>
    [Serializable]
    public class APP_USER : ILogicalThreadAffinative
    {
        public APP_USER()
        { }
        #region Model
        private string _token = string.Empty;
        private decimal _user_id;
        private string _user_code;
        private string _user_pwd;
        private string _user_name;
        private string _email;
        private string _is_available;
        private string _remark;
        private bool _is_login = false;
        private string _err_msg;
        private string _sesstion_id;

        
        /// <summary>
        /// 登录标记
        /// </summary>
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        /// <summary>
        /// 用户ID
        /// </summary>
        public decimal USER_ID
        {
            set { _user_id = value; }
            get { return _user_id; }
        }
        /// <summary>
        /// 用户代号
        /// </summary>
        public string USER_CODE
        {
            set { _user_code = value; }
            get { return _user_code; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string USER_PWD
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string USER_NAME
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 邮件地址
        /// </summary>
        public string EMAIL
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 是否可用
        /// </summary>
        public string IS_AVAILABLE
        {
            set { _is_available = value; }
            get { return _is_available; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string REMARK
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 登录是否成功
        /// </summary>
        public bool IS_Login
        {
            get { return _is_login; }
            set { _is_login = value; }
        }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string ErrMsg
        {
            get { return _err_msg; }
            set { _err_msg = value; }
        }

        /// <summary>
        /// 唯一标识
        /// </summary>
        public string SesstionId
        {
            get { return _sesstion_id; }
            set { _sesstion_id = value; }
        }
        
        #endregion Model
    }
    
}

