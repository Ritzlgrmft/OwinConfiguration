using Owin;
using System.Web.Http;

namespace OwinConfiguration
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// OWIN logging
			app.Use(typeof(Logger));

			// return exception details in case of an error
			app.UseShowExceptions(); 

			// Configure WebApi
			var config = new HttpConfiguration();
			config.Routes.MapHttpRoute("API Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
			app.UseWebApi(config);

			// Configure SignalR
			app.MapHubs();

			// Configure StaticFiles
			app.UseStaticFiles("StaticFiles");

			// Display 'Welcome to Kantana', when nothing else is found
			app.UseTestPage();
		}
	}
}
