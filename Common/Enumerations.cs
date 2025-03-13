using System;
using System.Collections.Generic;
using System.Text;

namespace Crownbio.Common
{
    /// <summary>
    /// UI中界面控件的值是否必须的属性及相应的颜色设定
    /// </summary>
    [Serializable]
    public enum FieldInputType
    {
        /// <summary>
        /// 空
        /// </summary>
        None = 0,
        /// <summary>
        /// 关键字栏位
        /// </summary>
        KeyField = 1,
        /// <summary>
        /// 必填栏位
        /// </summary>
        Required = 2,
        /// <summary>
        /// 可选栏位
        /// </summary>
        Option = 3,
        /// <summary>
        /// 只读栏位
        /// </summary>
        ReadOnly = 4,
        /// <summary>
        /// 只读但必要非空	
        /// </summary>
        ReadRequired = 5,
        /// <summary>
        /// 用户自定义栏位颜色
        /// </summary>
        UserOption1 = 6,
        /// <summary>
        /// 用户自定义栏位颜色
        /// </summary>
        UserOption2 = 7,

        /// <summary>
        /// 搜索栏位标签颜色
        /// </summary>
        Search = 8
    }

    /// <summary>
    /// Field的外键联接属性
    /// </summary>
    [Serializable]
    public enum TableJoinType
    {
        /// <summary>
        /// 无连接
        /// </summary>
        None = 0,
        /// <summary>
        /// INNER JOIN
        /// </summary>
        InnerJoin = 1,
        /// <summary>
        /// LEFT OUT JOIN
        /// </summary>
        LeftOuterJoin = 2,
        /// <summary>
        /// RIGHT OUT JOIN
        /// </summary>
        RightOuterJoin = 3,
        /// <summary>
        /// FULL OUT JOIN
        /// </summary>
        FullOuterJoin = 4
    }

    /// <summary>
    /// UI界面中控件的值需要做的验证类别
    /// </summary>
    [Serializable]
    public enum FieldRegType
    {
        /// <summary>
        /// 不做验证
        /// </summary>
        None = 0,
        /// <summary>
        /// 有效数值验证
        /// </summary>
        DecimalReg = 1,
        /// <summary>
        /// 带符号数值
        /// </summary>
        DecimalSignReg = 2,
        /// <summary>
        /// 正整数验证
        /// </summary>
        NumberReg = 3,
        /// <summary>
        /// 带符号整数
        /// </summary>
        NumberSignReg = 4,
        /// <summary>
        /// 邮件地址验证
        /// </summary>
        EmailReg = 5,
        /// <summary>
        /// 日期时间值
        /// </summary>
        DateTimeReg = 6,
        /// <summary>
        /// 电话号码值
        /// </summary>
        PhoneReg = 7,
        /// <summary>
        /// 身份证值
        /// </summary>
        IdCardReg = 8
    }

    /// <summary>
    /// 定义操作模式
    /// </summary>
    [Serializable]
    public enum DealModel
    {
        /// <summary>
        /// 查询
        /// </summary>
        Search = 0,
        /// <summary>
        /// 新增
        /// </summary>
        New = 1,
        /// <summary>
        /// 修改
        /// </summary>
        Modify = 2,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 3,
        /// <summary>
        /// 自定义
        /// </summary>
        None = 4
    }

    /// <summary>
    /// 子窗体的画面类型
    /// </summary>
    [Serializable]
    public enum TabPageType
    {
        /// <summary>
        /// Master资料维护
        /// </summary>
        MasterPage = 0,
        /// <summary>
        /// Detail资料维护
        /// </summary>
        DetailPage = 1,
        /// <summary>
        /// 资料导入界面
        /// </summary>
        ImportPage = 2,
        /// <summary>
        /// 报表界面
        /// </summary>
        ReportPage = 3,
        /// <summary>
        /// 用户自定义
        /// </summary>
        None = 4
    }

    /// <summary>
    /// 预定权限
    /// </summary>
    [Serializable]
    public class Operation
    {
        /// <summary>
        /// 目录权限
        /// </summary>
        public const decimal Cate = 10;
        /// <summary>
        /// 模块权限
        /// </summary>
        public const decimal Module = 20;
        /// <summary>
        /// 查询
        /// </summary>
        public const decimal Search = 30;
        /// <summary>
        /// 新增
        /// </summary>
        public const decimal Add = 31;
        /// <summary>
        /// 修改
        /// </summary>
        public const decimal Modify = 32;
        /// <summary>
        /// 删除
        /// </summary>
        public const decimal Delete = 33;
        /// <summary>
        /// 保存
        /// </summary>
        public const decimal Save = 34;
        /// <summary>
        /// 执行
        /// </summary>
        public const decimal Execute = 35;
        /// <summary>
        /// 导入
        /// </summary>
        public const decimal Import = 40;
        /// <summary>
        /// 导出
        /// </summary>
        public const decimal Export = 41;
        /// <summary>
        /// 打印
        /// </summary>
        public const decimal Print = 50;


        /// <summary>
        /// 预定功能1
        /// </summary>
        public const decimal Operation1 = 60;
        /// <summary>
        /// 预定功能2
        /// </summary>
        public const decimal Operation2 = 61;
        /// <summary>
        /// 预定功能3
        /// </summary>
        public const decimal Operation3 = 62;
        /// <summary>
        /// 预定功能4
        /// </summary>
        public const decimal Operation4 = 63;

    }


    /// <summary>
    /// 响应ENTER事件的类型
    /// </summary>
    public enum FieldKeyUpType
    {
        /// <summary>
        /// 正常响应，即等同于按下TAB键
        /// </summary>
        None = 0,
        /// <summary>
        /// 响应Key List
        /// </summary>
        List = 1,
        /// <summary>
        /// 主画面中的最后一个栏位，
        /// </summary>
        Stop = 2,
        /// <summary>
        /// 明细画面中的最后一个栏位
        /// </summary>
        StopDetail = 3,
        /// <summary>
        /// Multiline栏位，按下Enter后不将Focus移到下一栏位
        /// </summary>
        Memo = 4
    }
}
