using System.Web.Optimization;

namespace ReloadingApp.Configuration.Bundles.Resources
{
	/// <summary>Partial class for site resource bundles.</summary>
	public static partial class ResourceBundle
	{
		/// <summary>Returns the site js bundle.</summary>
		public static Bundle SiteJs
		{
			get
			{
				return new ScriptBundle("~/bundles/sitejs")
					.Include("~/Content/Site.js");
			}
		}

		/// <summary>Returns the site css bundle.</summary>
		public static Bundle SiteCss
		{
			get
			{
				return new StyleBundle("~/bundles/sitecss")
					.Include("~/Content/Site.css");
			}
		}
	}
}