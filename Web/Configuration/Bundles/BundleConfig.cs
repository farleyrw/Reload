using System.Linq;
using System.Reflection;
using System.Web.Optimization;
using Reload.Web.Configuration.Bundles.Resources;

namespace Reload.Web.Configuration.Bundles
{
	/// <summary>The bundle configuration</summary>
	public static class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			//BundleTable.EnableOptimizations = true;
			bundles.UseCdn = true;
			
			typeof(ResourceBundle).GetProperties(BindingFlags.Public | BindingFlags.Static).ToList().ForEach(property =>
			{
				bundles.Add((Bundle)property.GetValue(null));
			});
		}
	}
}