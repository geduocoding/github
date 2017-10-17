using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Model.Enum;

namespace App.Model.ResponseBody
{
    public class ResponseBase
    {
        /// <summary>
        /// 返回类型枚举（0:成功，1000：服务方法异常，1001:Api参数错误，1002：Json对象反序列化失败，验证前面失败，1004：网络连接失败
        /// </summary>
        public ResultTypeEnum ResultType { get; set; }
        /// <summary>
        /// 返回信息描述
        /// </summary>
        public string Message { get; set; }

    }

    public class Response<T>:ResponseBase
    {        
        public T Data { get; set; }

        public Response()
        {
        }

        public Response(T data, ResultTypeEnum resultType= ResultTypeEnum.Success)
        {
            this.ResultType = resultType;
            this.Data = data;
        }

        public Response(T data,string message,ResultTypeEnum resultType = ResultTypeEnum.Success)
        {
            this.ResultType = resultType;
            this.Data = data;
            this.Message = message;
        }

        public Response(ResultTypeEnum resultType, string message)
        {
            ResultType = resultType;
            Message = message;
        }
    }
}
