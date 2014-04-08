using System.Web.Optimization;

namespace Reload.Web.Bundles.Resources
{
	/// <summary>Site resource bundles.</summary>
	public class SiteResourceBundle : BaseResourceBundle
	{
		/// <summary>Returns the site js bundle.</summary>
		public static Bundle SiteJs
		{
			get
			{
				return new ScriptBundle("~/bundles/sitejs")
					.Include("~/Scripts/Site/Site.js");
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