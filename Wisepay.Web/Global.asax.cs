using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac.Integration.WebApi;

namespace Wisepay.Web
{
  using System.Configuration;
  using System.Data.Entity;
  using System.Reflection;

  using Autofac;
  using Autofac.Integration.Mvc;

  using Common.Logging.NLog;

  using Logging;

  using Repository;

  using UnitOfService;

  using UnitOfWork;

  using NLogLogger = Logging.NLog.NLogLogger;

  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {

      var builder = new ContainerBuilder();
      RegisterTypes(builder);
      var container = builder.Build();

      var webApiResolver = new AutofacWebApiDependencyResolver(container);
      GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

    }
    private static void RegisterTypes(ContainerBuilder builder)
    {
      builder.RegisterControllers(typeof(MvcApplication).Assembly);

      builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

      var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

   //   builder.RegisterType<WisepayContext>()
   //.As<DbContext>()
   //.WithParameter("connectionstring", connectionString).InstancePerLifetimeScope();

      var repositories = Assembly.Load("Repository");
      builder.RegisterAssemblyTypes(repositories).AsImplementedInterfaces().InstancePerLifetimeScope();

      var unitOfWork = Assembly.Load("UnitOfWork");
      builder.RegisterAssemblyTypes(unitOfWork).AsImplementedInterfaces()
        .WithParameter("connectionstring", connectionString)
        .InstancePerLifetimeScope();

      var serviceAssemblies = Assembly.Load("WisepayServices");
      builder.RegisterAssemblyTypes(serviceAssemblies).AsImplementedInterfaces().InstancePerLifetimeScope();


      builder.RegisterType<NLogLogger>().As<ILogger>().InstancePerLifetimeScope();


      var unitOfService = Assembly.Load("UnitOfService");
      builder.RegisterAssemblyTypes(unitOfService).AsImplementedInterfaces().InstancePerLifetimeScope();


      var config = GlobalConfiguration.Configuration;
      builder.RegisterWebApiFilterProvider(config);

      builder.RegisterFilterProvider();
    }
  }
}
