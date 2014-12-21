using System.Web.Optimization;
using Reload.Web.Bundles;

namespace Reload.Web.Areas.Firearms
{
	/// <summary>The firearm resource bundles.</summary>
	public class FirearmsResourceBundle : BaseResourceBundle
	{
		/// <summary>Returns the firearms js bundle.</summary>
		public static Bundle FirearmsJs
		{
			get
			{
				return new ScriptBundle("~/bundles/firearms")
					.Include(
						"~/Scripts/reload/web/services.js",
						"~/Scripts/reload/filters/helpers.js",
						"~/Scripts/reload/ui/controls.js",
						"~/Scripts/reload/ui/effects.js",
						"~/Scripts/reload/ui/widgets.js",
						"~/Areas/Firearms/Scripts/reload/services.js",
						"~/Areas/Firearms/Scripts/reload/controllers.js",
						"~/Areas/Firearms/Scripts/firearmmanager.js"
					);
			}
		}
	}
}