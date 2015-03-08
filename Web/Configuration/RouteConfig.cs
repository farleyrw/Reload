using System.Web.Mvc;
using System.Web.Routing;

namespace Reload.Web.Configuration
{
	/// <summary>The base route configuration for the application.</summary>
	public static class RouteConfig
	{
		/// <summary>Registers the routes.</summary>
		/// <param name="routes">The routes.</param>
		/// <param name="disableTestingCrap">if set to <c>true</c> [disable testing crap].</param>
		public static void RegisterRoutes(RouteCollection routes, bool disableTestingCrap = false)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			if(!disableTestingCrap)
			{
				routes.MapMvcAttributeRoutes();
			
				AreaRegistration.RegisterAllAreas();
			}

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}