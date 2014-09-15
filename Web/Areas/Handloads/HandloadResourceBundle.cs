using System.Web.Optimization;
using Reload.Web.Bundles;

namespace Reload.Web.Areas.Handloads
{
	/// <summary>The hanload resource bundles.</summary>
	public class HandloadResourceBundle : BaseResourceBundle
	{
		/// <summary>Returns the handload js bundle.</summary>
		public static Bundle HanloadJs
		{
			get
			{
				return new ScriptBundle("~/bundles/handloads")
					.Include(
						"~/Scripts/reload/angular/services.js",
						"~/Scripts/reload/angular/filters.js",
						"~/Scripts/reload/angular/providers.js",
						"~/Scripts/reload/angular/directives.js",
						"~/Scripts/reload/angular/modules/Authorization.js",
						"~/Areas/Firearms/Scripts/FirearmService.js",
						"~/Areas/Handloads/Scripts/HandloadManager.js"
					);
			}
		}
	}
}