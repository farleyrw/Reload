using System.Linq;
using System.Reflection;
using System.Web.Optimization;
using Reload.Web.Bundles;

namespace Reload.Web.Configuration
{
	/// <summary>The bundle configuration.</summary>
	public static class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			//BundleTable.EnableOptimizations = true;
			bundles.UseCdn = true;

			var resources = typeof(BaseResourceBundle).Assembly.GetTypes()
				.Where(type => type.IsClass && type.IsSubclassOf(typeof(BaseResourceBundle)))
				.SelectMany(type => type.GetProperties(BindingFlags.Public | BindingFlags.Static))
				.ToList();

			resources.ForEach(property =>
			{
				bundles.Add((Bundle)property.GetValue(null));
			});
		}
	}
}