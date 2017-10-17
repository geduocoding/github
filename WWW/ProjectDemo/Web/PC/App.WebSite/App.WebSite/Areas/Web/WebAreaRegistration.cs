using System.Web.Mvc;

namespace App.WebSite.Areas.Web
{
    public class WebAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Web";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Web_default",
                "Web/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new string[] { "App.WebSite.Areas.Web.Controllers" }
            );
        }
    }
}