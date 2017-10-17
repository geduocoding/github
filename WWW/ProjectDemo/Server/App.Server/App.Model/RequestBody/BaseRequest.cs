using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.RequestBody
{
    public class BaseRequest
    {
        /// <summary>
        /// 令牌Token
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 每页行数
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 分页开始序号
        /// </summary>
        public int PageStart
        {
            get { return (this.PageIndex - 1) * this.PageSize; }
        }
        /// <summary>
        /// 分页结束序号
        /// </summary>
        public int PageEnd
        {
            get { return this.PageIndex * this.PageSize; }
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderField { get; set; }
        /// <summary>
        /// 排序类型(0 升序 1降序)
        /// </summary>
        public SortOrder SortOrder { get; set; }
    }
}
