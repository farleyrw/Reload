using System.Web.Optimization;
using Reload.Web.Bundles;

namespace Reload.Web.Areas.User
{
	/// <summary>The user resource bundles.</summary>
	public class UserResourceBundles : BaseResourceBundle
	{
		/// <summary>Returns the user manager js bundle.</summary>
		public static Bundle UserManager
		{
			get
			{
				return new ScriptBundle("~/bundles/usermanager")
					.Include("~/Areas/User/Scripts/usermanager.js");
			}
		}
	}
}