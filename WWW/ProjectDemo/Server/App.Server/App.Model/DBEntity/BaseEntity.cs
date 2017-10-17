using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.DBEntity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.CreateTime = DateTime.Now;
            this.ModifyTime = DateTime.Now;
            this.ID = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }
    }
}
