using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Reload.Common.Authentication;
using ReloadingApp.Authentication;
using ReloadingApp.Configuration;
using ReloadingApp.Configuration.Bundles;
using ReloadingApp.Configuration.Dependencies;

namespace ReloadingApp
{
	/// <summary>The base configuration of the MVC application.</summary>
	public class MvcApplication : HttpApplication
	{
		/// <summary>Application_s the start.</summary>
		protected void Application_Start()
		{
			DatabaseConfig.Initialize();

			AreaRegistration.RegisterAllAreas();

			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			ViewEngineConfig.RegisterCustomViewEngines(ViewEngines.Engines);

			DependencyConfig.Initialize();
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
		private static void MvcApplication_PostAuthenticateRequest(object sender, System.EventArgs e)
		{
			HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

			UserIdentity identity = MvcAuthentication.GetUserIdentity(authCookie);

			if(identity == null || !identity.HasData()) { return; }

			HttpContext.Current.User = new UserPrincipal(identity);
		}
	}
}