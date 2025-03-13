using System;
using System.Collections.Generic;
using System.Text;

namespace Crownbio.Common
{



    public enum STATUS_TYPE
    {
        未开始,
        进行中,
        修改,           /// 与进行中属于同级 
        完成编制,       /// 提交负责人
        已提交,         /// 负责人提交
        申请撤销,       /// 文档编制向负责人提出
        审批中,         /// 项目开始审批
        审批通过,       /// 审批流程通过
        结束,
        空
    }

    /// 大纲(DCM_DOCUMENT): 未开始 -> 进行中(修改) -> 已提交 -> 审批中-> 审批通过 -> 结束
    /// 文档(DCM_DOCUMENT_OUTLINE): 未开始 -> 进行中(修改) -> 已提交(申请撤销) ->  完成编制

    public enum wError
    {
        正确 = 0,

        /// 本地错误
        本地文档不存在 = 1,
        文档正在本另一个进程访问 = 2,
        文档删除失败 = 3,

        /// 服务器端错误或者网络错误
        服务器端文档不存在 = 11,
        文档下载失败 = 12

    }

    /// <summary>
    /// 节点的类型
    /// </summary>
    public enum TypeProjectNode
    {
        Project = 0,
        DocumentR = 1,
        Document = 2,
        Other = 3
    }


    /// <summary>
    /// 文档状态
    /// </summary>
    //public enum DocumentStatus
    //{
    //    未开始 = 0,
    //    进行中 = 1,
    //    已提交 = 2,
    //    修改 = 3
    //}


    /// <summary>
    /// 类型
    /// </summary>
    public enum DcmNodeType
    {
        文档结构 = 0,
        项目列表 = 1,
        模板管理 = 2,
        文档 = 3,
        其他 = 4
    }


    /// <summary>
    /// 角色类型
    /// </summary>
    public enum DCM_ROLE_TYPE
    {
        文档编制人 = 0,
        项目负责人 = 1,
        项目参与人员 = 2,
        审批人员 = 3,
        文档负责人 = 4,
        部门经理 = 5,
        主管领导 = 6,
        专家 = 7,
        其他 = 8,
    }


    public class DCM_ROLE
    {
        public DCM_ROLE()
        {

        }
        //所有者 = 0,
        //项目负责人 = 1,
        //项目参与人员 = 2,
        //审批人员 = 3,
        //文档负责人 = 4,
        //部门经理 = 5,
        //主管领导 = 6,
        //专家 = 7,
        //其他 = 8,
        public void getPerm(DCM_ROLE_TYPE type)
        {
            switch (type)
            {
                case DCM_ROLE_TYPE.文档负责人:
                    is_charge = true;
                    break;
                case DCM_ROLE_TYPE.审批人员:
                    is_auditor = true;
                    break;
                case DCM_ROLE_TYPE.项目负责人:
                    is_pro_charge = true;
                    break;
                case DCM_ROLE_TYPE.主管领导:
                    is_leader = true;
                    break;
                case DCM_ROLE_TYPE.部门经理:
                    is_manager = true;
                    break;
            }
        }


        public void getPerm(string role)
        {
            getPerm(StringToEnum(role));

        }



        /// <summary>
        /// 用户当前角色
        /// </summary>
        private DCM_ROLE_TYPE role_type;
        public DCM_ROLE_TYPE ROLE_TYPE
        {
            get { return role_type; }
            set { role_type = value; }
        }


        /// <summary>
        /// 是否是部门经理
        /// </summary>
        private bool is_manager;
        public bool IS_MANAGER
        {
            get { return is_manager; }
            set { is_manager = value; }
        }

        /// <summary>
        /// 是否是编制人
        /// </summary>
        private bool is_writer;
        public bool IS_WRITER
        {
            get { return is_writer; }
            set { is_writer = value; }
        }

        /// <summary>
        /// 是否是审核人员
        /// </summary>
        private bool is_auditor;
        public bool IS_AUDITOR
        {
            get { return is_auditor; }
            set { is_auditor = value; }
        }

        /// <summary>
        /// 是否是主管领导
        /// </summary>
        private bool is_leader;
        public bool IS_LEADER
        {
            get { return is_leader; }
            set { is_leader = value; }
        }

        /// <summary>
        /// 是否是负责人
        /// </summary>
        private bool is_charge;
        public bool IS_CHARGE
        {
            get { return is_charge; }
            set { is_charge = value; }
        }

        /// <summary>
        /// 是否是负责人
        /// </summary>
        private bool is_pro_charge;
        public bool IS_PRO_CHARGE
        {
            get { return is_pro_charge; }
            set { is_pro_charge = value; }
        }

        /// <summary>
        /// 是否是专家
        /// </summary>
        private bool is_expert;
        public bool IS_EXPERT
        {
            get { return is_expert; }
            set { is_expert = value; }
        }




        #region 公用方法
        public static string EnumToString(DCM_ROLE_TYPE type)
        {
            int index = (int)type;
            string role = index.ToString();
            while (role.Length > 2)
            {
                role = "0" + role;
            }
            return role;
        }

        public static DCM_ROLE_TYPE StringToEnum(string role)
        {
            int index = int.Parse(role);
            DCM_ROLE_TYPE type = DCM_ROLE_TYPE.其他;
            if (index >= 0 && index <= 8)
                type = (DCM_ROLE_TYPE)index;
            return type;
        }
        #endregion
    }







    /*
    01、项目负责人
    02、项目参与人员
    03、审批人员
    04、文档负责人
    05、部门经理
    06、主管领导
    07、专家
     */
}
