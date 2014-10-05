using System.Web.Optimization;
using Reload.Web.Bundles;

namespace Reload.Web.Areas.Firearms
{
	/// <summary>The firearm resource bundles.</summary>
	public class FirearmResourceBundle : BaseResourceBundle
	{
		/// <summary>Returns the firearms js bundle.</summary>
		public static Bundle FirearmsJs
		{
			get
			{
				return new ScriptBundle("~/bundles/firearms")
					.Include(
						"~/Scripts/reload/providers/authorization.js",
						"~/Scripts/reload/web/services.js",
						"~/Scripts/reload/filters/helpers.js",
						"~/Scripts/reload/directives/controls.js",
						"~/Scripts/reload/ui/widgets.js",
						"~/Scripts/modules/authorization.js",
						"~/Areas/Firearms/Scripts/Reload/Services.js",
						"~/Areas/Firearms/Scripts/FirearmManager.js"
					);
			}
		}
	}
}