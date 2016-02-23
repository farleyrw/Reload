using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Optimization;
using Reload.Web.Bundles.Transforms;

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
					.Include("~/Scripts/reload/reload.js");
			}
		}

		/// <summary>Returns the authorization js bundle.</summary>
		public static Bundle Authorization
		{
			get
			{
				return new ScriptBundle("~/bundles/authorization")
					.Include("~/Scripts/reload/providers/authorization.js");
			}
		}

		/// <summary>Returns the reload ui js bundle.</summary>
		public static Bundle ReloadUiJs
		{
			get
			{
				return new ScriptBundle("~/bundles/reloaduijs")
					.Include(
						"~/Scripts/reload/ui/controls.js",
						"~/Scripts/reload/ui/effects.js",
						"~/Scripts/reload/ui/widgets.js",
						"~/Scripts/reload/ui/ui.js"
					);
			}
		}

		/// <summary>Returns the reload events js bundle.</summary>
		public static Bundle ReloadEvents
		{
			get
			{
				return new ScriptBundle("~/bundles/reloadevents")
					.Include("~/Scripts/reload/events/mediator.js");
			}
		}

		/// <summary>Returns the app config js bundle.</summary>
		public static Bundle AppConfig
		{
			get
			{
				CompilationSection compilationSection = (CompilationSection)ConfigurationManager.GetSection(@"system.web/compilation");

				string isDebug = compilationSection.Debug.ToString().ToLower();

				NameValueCollection configSettings = new NameValueCollection();

				configSettings.Add("IsDebug", isDebug);
				configSettings.Add("SessionTimeout", "30");
				
				Bundle configBundle = new ScriptBundle("~/bundles/appconfig")
					.Include(
						"~/Scripts/reload/config/app.js",
						new NameValueBundleTransform(configSettings, "IsDebug", "SessionTimeout"));

				configBundle.Transforms.Clear();

				return configBundle;
			}
		}
	}
}