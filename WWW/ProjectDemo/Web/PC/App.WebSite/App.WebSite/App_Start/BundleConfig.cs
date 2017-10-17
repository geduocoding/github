using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Newtonsoft.Json;

namespace App.WebSite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            var s = System.IO.File.ReadAllText(System.Web.HttpContext.Current.Server
              .MapPath("~/content/package.json"));
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string[]>>(s);
            foreach (var d in dict)
            {
                var items = d.Value;
                if (items[0].ToLower().EndsWith(".css"))
                {
                    bundles.Add(new StyleBundle(d.Key).Include(items));
                }
                if (items[0].ToLower().EndsWith(".js"))
                {
                    bundles.Add(new ScriptBundle(d.Key).Include(items));
                }
            }

            // Code removed for clarity.
        }
    }
}