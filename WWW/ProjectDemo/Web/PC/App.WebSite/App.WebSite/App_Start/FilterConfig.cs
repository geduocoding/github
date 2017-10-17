using App.Server.Filters;
using App.WebSite.Filters.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.WebSite.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());    
      

            filters.Add(new LogFilterAttribute());
            filters.Add(new ExceptionHandlerFilterAttribute());
        }  
    }
}