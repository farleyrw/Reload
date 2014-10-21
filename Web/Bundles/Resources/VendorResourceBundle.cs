using System.Web.Optimization;

namespace Reload.Web.Bundles.Resources
{
	/// <summary>Vendor resource bundles.</summary>
	public class VendorResourceBundle : BaseResourceBundle
	{
		/// <summary>Returns the jquery js bundle.</summary>
		public static Bundle JqueryJs
		{
			get
			{
				Bundle jqueryBundle = new ScriptBundle("~/bundles/jqueryjs",
						"//ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js")
					.Include("~/Scripts/jquery/jquery-{version}.js");

				jqueryBundle.CdnFallbackExpression = "window.jQuery";

				return jqueryBundle;
			}
		}

		/// <summary>Returns the jquery validation bundle.</summary>
		public static Bundle JqueryValidation
		{
			get
			{
				return new ScriptBundle("~/bundles/jqueryvalidation")
					.Include(
						"~/Scripts/jquery/validation/jquery.unobtrusive-ajax.js",
						"~/Scripts/jquery/validation/jquery.validate.js",
						"~/Scripts/jquery/validation/jquery.validate.unobtrusive.js"
					);
			}
		}

		/// <summary>Returns the angular js bundle.</summary>
		public static Bundle AngularJs
		{
			get
			{
				return new ScriptBundle("~/bundles/angularjs")
					.Include(
						"~/Scripts/angular/angular.js",
						"~/Scripts/angular/angular-resource.js",
						"~/Scripts/angular/angular-loader.js",
						"~/Scripts/angular/angular-route.js"
					);
			}
		}

		/// <summary>Gets the angular ui bundle.</summary>
		public static Bundle AngularUi
		{
			get
			{
				return new ScriptBundle("~/bundles/angularui")
					.Include(
						"~/Scripts/angular-ui/ui-bootstrap.js",
						"~/Scripts/angular-ui/ui-bootstrap-tpls.js"
					);
			}
		}

		/// <summary>Gets the angular block ui bundle.</summary>
		public static Bundle AngularBlockUi
		{
			get
			{
				return new ScriptBundle("~/bundles/angularblockuijs")
					.Include("~/Scripts/angular-block-ui/angular-block-ui.js");
			}
		}

		/// <summary>Gets the angular block ui css bundle.</summary>
		public static Bundle AngularBlockUiCss
		{
			get
			{
				return new StyleBundle("~/bundles/angularblockuicss")
					.Include("~/Content/angular-block-ui/angular-block-ui.css");
			}
		}

		/// <summary>Gets the bootstrap css bundle.</summary>
		public static Bundle BootStrap
		{
			get
			{
				return new StyleBundle("~/bundles/bootstrapcss")
					.Include("~/Content/bootstrap/bootstrap.css");
			}
		}
	}
}