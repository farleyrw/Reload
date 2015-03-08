using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Reload.Common.Authentication.Mvc;
using Reload.Web.Configuration;

namespace Reload.Web
{
	/// <summary>The base configuration of the MVC application.</summary>
	public class MvcApplication : HttpApplication
	{
		/// <summary>Initializes the application.</summary>
		protected void Application_Start()
		{
			DatabaseConfig.RegisterInitializers();

			DependencyConfig.Initialize();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			ViewEngineConfig.RegisterCustomViewEngines(ViewEngines.Engines);
			ModelBinderConfig.RegisterModelBinders(ModelBinders.Binders);
		}

		/// <summary>Executes custom initialization code after all event handler modules have been added.</summary>
		public override void Init()
		{
			base.Init();

			PostAuthenticateRequest += MvcAuthentication.MvcApplication_PostAuthenticateRequest;
		}
	}
}