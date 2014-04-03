using System.Web.Optimization;

namespace Reload.Web.Configuration.Bundles.Resources
{
	/// <summary>Partial class for common resource bundles.</summary>
	public static partial class ResourceBundle
	{
		/// <summary>Returns the html5 shiv js bundle.</summary>
		public static Bundle Html5Shiv
		{
			get
			{
				return new ScriptBundle("~/bundles/html5shiv")
					.Include("~/Scripts/html5/html5shiv.js");
			}
		}

		/// <summary>Returns the jquery js bundle.</summary>
		public static Bundle JqueryJs
		{
			get
			{
				Bundle jqueryBundle = new ScriptBundle("~/bundles/jqueryjs",
						"//ajax.googleapis.com/ajax/libs/jquery/2.1.0/jquery.min.js")
					.Include("~/Scripts/jquery/jquery-{version}.js");

				jqueryBundle.CdnFallbackExpression = "window.jQuery";

				return jqueryBundle;
			}
		}

		/// <summary>Returns the jquery ui js bundle.</summary>
		public static Bundle JqueryUiJs
		{
			get
			{
				Bundle jqueryUiBundle = new ScriptBundle("~/bundles/jqueryuijs",
						"//ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js")
					.Include("~/Scripts/jquery/ui/jquery-ui-{version}.custom.js");

				jqueryUiBundle.CdnFallbackExpression = "window.jQuery.ui";

				return jqueryUiBundle;
			}
		}

		/// <summary>Returns the jquery ui css bundle.</summary>
		public static Bundle JqueryUiCss
		{
			get
			{
				// This path is important because of embedded relative resource references.
				return new StyleBundle("~/Content/themes/Reload/jqueryuicss")
					.Include("~/Content/themes/Reload/jquery-ui-{version}.custom.css");
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
				Bundle angularBundle = new ScriptBundle("~/bundles/angularjs",
						"//ajax.googleapis.com/ajax/libs/angularjs/1.2.14/angular.min.js")
					.Include("~/Scripts/angular/angular.js");

				angularBundle.CdnFallbackExpression = "window.angular";

				return angularBundle;
			}
		}

		/// <summary>Gets the angular resource js bundle.</summary>
		public static Bundle AngularResourceJs
		{
			get
			{
				return new ScriptBundle("~/bundles/angularresourcejs",
						"//ajax.googleapis.com/ajax/libs/angularjs/1.2.14/angular-resource.min.js")
					.Include("~/Scripts/angular/angular-resource.js");
			}
		}

		/// <summary>Gets the angular loader js bundle.</summary>
		public static Bundle AngularLoaderJs
		{
			get
			{
				return new ScriptBundle("~/bundles/angularloaderjs",
						"//ajax.googleapis.com/ajax/libs/angularjs/1.2.14/angular-loader.min.js")
					.Include("~/Scripts/angular/angular-loader.js");
			}
		}

		/// <summary>Gets the angular route js bundle.</summary>
		public static Bundle AngularRouteJs
		{
			get
			{
				return new ScriptBundle("~/bundles/angularroutejs",
						"//ajax.googleapis.com/ajax/libs/angularjs/1.2.14/angular-route.min.js")
					.Include("~/Scripts/angular/angular-route.js");
			}
		}

		/// <summary>Gets the angular ui bundle.</summary>
		public static Bundle AngularUi
		{
			get
			{
				return new ScriptBundle("~/bundles/angularui")
					.Include(
						"~/Scripts/angular/ui/ui-bootstrap-{version}.js",
						"~/Scripts/angular/ui/ui-bootstrap-tpls-{version}.js"
					);
			}
		}

		/// <summary>Gets the bootstrap css bundle</summary>
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