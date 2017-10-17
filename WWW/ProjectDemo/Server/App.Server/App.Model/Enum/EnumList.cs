using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.Enum
{
    public enum ResultTypeEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 0,
        /// <summary>
        /// 服务方法异常
        /// </summary>
        [Description("服务方法异常,错误号:{0}")]
        ServiceException = 1000,
        /// <summary>
        /// Api参数错误
        /// </summary>
        [Description("Api参数错误,错误号:{0}")]
        ApiParamError = 1001,
        /// <summary>
        /// Json对象反序列化失败
        /// </summary>
        [Description("Json对象反序列化失败,错误号:{0}")]
        JsonDeserializeFailed = 1002,
        /// <summary>
        /// 验证签名失败
        /// </summary>
        [Description("验证签名失败,错误号:{0}")]
        ValidateSignFailed = 1003,
        /// <summary>
        /// 网络连接失败
        /// </summary>
        [Description("网络连接失败,错误号:{0}")]
        HttpError = 1004
    }
}
