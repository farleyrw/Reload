using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Reload.Common.Authentication.Mvc;
using Reload.Web.Configuration;
using Reload.Web.Configuration.Bundles;

namespace Reload.Web
{
	/// <summary>The base configuration of the MVC application.</summary>
	public class MvcApplication : HttpApplication
	{
		/// <summary>Initializes the application.</summary>
		protected void Application_Start()
		{
			DatabaseConfig.RegisterInitializers();

			AreaRegistration.RegisterAllAreas();

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

			PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
		}

		/// <summary>Handles the PostAuthenticateRequest event of the MvcApplication control.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private static void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
		{
			UserIdentity identity = MvcAuthentication.GetUserIdentity();

			if(identity == null || !identity.HasData()) { return; }

			HttpContext.Current.User = new UserPrincipal(identity);
		}
	}
}