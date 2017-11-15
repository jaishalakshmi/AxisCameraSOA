
using Microsoft.Owin;

using Owin;

using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;
[assembly: OwinStartup(typeof(AxiscamWeb.Startup))]
namespace AxiscamWeb
{
    public class Startup
    {
        //public void Configuration(IAppBuilder appBuilder)
        //{
        //    HttpConfiguration httpConfiguration = new HttpConfiguration();
        //    WebApiConfig.Register(httpConfiguration);
        //    appBuilder.UseWebApi(httpConfiguration);
        //    appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        //    appBuilder.UseWebApi(httpConfiguration);
        //}

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            //config.Routes.IgnoreRoute("FilesRoute", "content/{*pathInfo}");
            // config.Routes.IgnoreRoute("Content/{*pathInfo}");
            config.EnableCors();
            config.EnableCors(new EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE"));
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            // RouteConfig.RegisterRoutes(RouteTable.Routes);
            WebApiConfig.Register(config);
            
            app.UseWebApi(config); app.Use(async (context, next) =>
            {
                IOwinRequest req = context.Request;
                IOwinResponse res = context.Response;
                if (req.Path.StartsWithSegments(new PathString("/Token")))
                {
                    var origin = req.Headers.Get("Origin");
                    if (!string.IsNullOrEmpty(origin))
                    {
                        res.Headers.Set("Access-Control-Allow-Origin", origin);
                    }
                    if (req.Method == "OPTIONS")
                    {
                        res.StatusCode = 200;
                        res.Headers.AppendCommaSeparatedValues("Access-Control-    Allow-Methods", "GET", "POST");
                        res.Headers.AppendCommaSeparatedValues("Access-Control-    Allow-Headers", "authorization", "content-type");
                        return;
                    }
                }
                await next();
            });
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<AuthContext, ExpenseBuddy.Migrations.Configuration>());

        }
    }
}