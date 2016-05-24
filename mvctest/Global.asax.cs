using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Qiuqiu.Service;
using Qiuqiu.Test.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace mvctest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContainerBuilder builder = new ContainerBuilder();
            Register(builder);
        }

        private void Register(ContainerBuilder builder)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());//注册api容器的实现
            builder.RegisterControllers(Assembly.GetExecutingAssembly());//注册mvc容器的实现
            builder.RegisterType(typeof(Test)).As(typeof(ITest));
            //autofac 注册依赖
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
