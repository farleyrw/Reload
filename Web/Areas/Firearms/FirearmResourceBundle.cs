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
				return new ScriptBundle("~/bundles/firearm")
					.IncludeDirectory("~/Areas/Firearms/Scripts", "*.js");
			}
		}
	}
}