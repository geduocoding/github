using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.RequestBody
{
    public class UserRequest:BaseRequest
    {
        /// <summary>
        /// 登录账户
        /// </summary>
        public string Account { get; set; }
    }
}
