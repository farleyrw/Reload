using System.Web.Optimization;

namespace Reload.Web.Bundles.Resources
{
	/// <summary>Site resource bundles.</summary>
	public class SiteResourceBundle : BaseResourceBundle
	{
		/// <summary>Returns the site css bundle.</summary>
		public static Bundle SiteCss
		{
			get
			{
				return new StyleBundle("~/bundles/sitecss")
					.Include("~/Content/Site.css");
			}
		}
		
		/// <summary>Returns the reload js bundle.</summary>
		public static Bundle ReloadJs
		{
			get
			{
				return new ScriptBundle("~/bundles/reloadjs")
					.Include("~/Scripts/Reload/Reload.js");
			}
		}

		/// <summary>Returns the authorization js bundle.</summary>
		public static Bundle Authorization
		{
			get
			{
				return new ScriptBundle("~/bundles/authorization")
					.Include(
						"~/Scripts/reload/providers/authorization.js",
						"~/Scripts/modules/authorization.js"
					);
			}
		}

		/// <summary>Returns the session js bundle.</summary>
		public static Bundle Session
		{
			get
			{
				return new ScriptBundle("~/bundles/session")
					.Include(
						"~/Scripts/angular/angular-cookies.js",
						"~/Scripts/modules/session.js"
					);
			}
		}
	}
}