using System.Reflection;
using System.Web.Http;
using AutoFacWebApi;
using Microsoft.Owin;
using Autofac;
using Autofac.Integration.WebApi;
using AutoFacWebApi.Controllers;
using AutoFacWebApi.Services;
using Owin;
[assembly: OwinStartup("ProductionConfiguration", typeof(AutoFacWebApi.Startup))]
namespace AutoFacWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // In OWIN you create your own HttpConfiguration rather than
            // re-using the GlobalConfiguration.
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional });

            var builder = new ContainerBuilder();
            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);

            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}