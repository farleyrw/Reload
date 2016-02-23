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
						"~/Scripts/reload/web/services.js",
						"~/Scripts/reload/filters/helpers.js",
						"~/Areas/Firearms/Scripts/Reload/Services.js",
						"~/Areas/Handloads/Scripts/Reload/Services.js",
						"~/Areas/Handloads/Scripts/Reload/Controllers.js",
						"~/Areas/Handloads/Scripts/HandloadManager.js"
					);
			}
		}
	}
}