using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Model.RequestBody;
using App.Model.ResponseBody;
using App.Framework.Server;
using App.Model.DBEntity;
using App.Framework.BaseEntity;

namespace App.WebSite.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUserList(UserRequest request)
        {
            var result = ServiceHandler.Instance.Request<Response<Page<sys_User>>> ("GetUsersFor", request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}