using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace App.Server.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            HttpConfiguration configuration = GlobalConfiguration.Configuration;
            var assemblyList = AppDomain.CurrentDomain.GetAssemblies();
            //var assemblyList = Assembly.GetExecutingAssembly();
            builder.RegisterWebApiFilterProvider(configuration);

            //var iServices = Assembly.Load("App.IService");
            //var services = Assembly.Load("App.Service");
            //var iRepository = Assembly.Load("App.IRepository");
            //var repository = Assembly.Load("App.Repository");
            //builder.RegisterAssemblyTypes(iServices, services)
            //    .Where(t => t.Name.EndsWith("Service"))
            //    .AsImplementedInterfaces();
            //var test = builder.RegisterAssemblyTypes(iRepository, repository)
            //     .Where(t => t.Name.EndsWith("Repository"))
            //     .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(assemblyList)
                .Where(t => t.Name.EndsWith("Service") || t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();    //注册所有controller
            builder.RegisterApiControllers(assemblyList).PropertiesAutowired();    //注册所有apicontroller
            var container = builder.Build();
            configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);//注册api容器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//注册mvc容器
        }
    }
}