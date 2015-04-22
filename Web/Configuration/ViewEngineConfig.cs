using System.Collections.Generic;
using System.Web.Mvc;

namespace Reload.Web.Configuration
{
	/// <summary>The view enging configuration.</summary>
	public static class ViewEngineConfig
	{
		/// <summary>Registers the view engines for the application.</summary>
		/// <param name="viewEngines">The view engines.</param>
		public static void RegisterViewEngines(ICollection<IViewEngine> viewEngines)
		{
			string[] viewPaths = new[]
			{
				"~/Views/{1}/{0}.cshtml",
				"~/Views/Shared/{0}.cshtml",
				"~/Views/{0}.cshtml"
			};

			string[] areaViewPaths = new[]
			{
				"~/Areas/{2}/Views/{1}/{0}.cshtml",
				"~/Areas/{2}/Views/Shared/{0}.cshtml",
				"~/Areas/{2}/Views/{0}.cshtml", 
				"~/Views/Shared/{0}.cshtml"
			};

			// Remove web forms and vb view paths since this is pure a C# MVC app and they slow things down.
			viewEngines.Clear();

			viewEngines.Add(new RazorViewEngine
			{
				ViewLocationFormats = viewPaths,
				PartialViewLocationFormats = viewPaths,
				AreaViewLocationFormats = areaViewPaths,
				AreaPartialViewLocationFormats = areaViewPaths,
				FileExtensions = new[] { "cshtml" }
			});
		}
	}
}