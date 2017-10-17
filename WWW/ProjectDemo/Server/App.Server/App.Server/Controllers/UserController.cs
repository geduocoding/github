using App.Framework.BaseEntity;
using App.IService;
using App.Model.DBEntity;
using App.Model.RequestBody;
using App.Model.ResponseBody;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.Server.Controllers
{
    /// <summary>
    /// 用户模块
    /// </summary>
    public class UserController : ApiController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Response<Page<sys_User>> GetUsersFor([FromBody] UserRequest request)
        {
            return new Response<Page<sys_User>>(_userService.GetUsersFor(request));
        }
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Response<int> AddUser([FromBody] sys_User request)
        {
            return new Response<int>(_userService.AddUser(request));
        }

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public Response<int> UpdateUser([FromBody] sys_User request)
        {
            return new Response<int>(_userService.UpdateUser(request));
        }
    }
}
