using System.Web.Optimization;
using ReloadingApp.Configuration.Bundles.Resources;

namespace ReloadingApp.Configuration.Bundles
{
	/// <summary>The bundle configuration</summary>
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{
			//BundleTable.EnableOptimizations = true;
			bundles.UseCdn = true;

			bundles.Add(ResourceBundle.Html5Shiv);

			bundles.Add(ResourceBundle.JqueryJs);
			bundles.Add(ResourceBundle.JqueryUiJs);
			bundles.Add(ResourceBundle.JqueryUiCss);
			bundles.Add(ResourceBundle.JqueryValidation);

			bundles.Add(ResourceBundle.AngularJs);
			bundles.Add(ResourceBundle.AngularLoaderJs);
			bundles.Add(ResourceBundle.AngularResourceJs);
			bundles.Add(ResourceBundle.AngularRouteJs);

			bundles.Add(ResourceBundle.SiteCss);
		}
	}
}