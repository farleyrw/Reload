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
				return new ScriptBundle("~/bundles/handload")
					.Include("~/Areas/Hanloads/Scripts/Application.js");
			}
		}
	}
}