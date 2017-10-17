using App.Framework.Attributes;
using System;
using System.Collections.Generic;


namespace App.Model.DBEntity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    [DBTable("sys_User", "dbo")]
    public class sys_User : BaseEntity
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>	
        public string Password { get; set; }
        /// <summary>
        /// Name
        /// </summary>	
        public string Name { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>	
        public string Nickname { get; set; }
        /// <summary>
        /// Gender
        /// </summary>	
        public int Gender { get; set; }
        /// <summary>
        /// 账号状态（1-启用 0-禁用 -1-已删除）
        /// </summary>	
        public int Status { get; set; }
        /// <summary>
        /// IsLimitIP
        /// </summary>	
        public bool IsLimitIP { get; set; }
        /// <summary>
        /// MaxIPCount
        /// </summary>	
        public int MaxIPCount { get; set; }
        /// <summary>
        /// LoginID
        /// </summary>	
        public string LoginID { get; set; }
        /// <summary>
        /// Email
        /// </summary>	
        public string Email { get; set; }
        /// <summary>
        /// Mobile
        /// </summary>	
        public string Mobile { get; set; }
    }
}
