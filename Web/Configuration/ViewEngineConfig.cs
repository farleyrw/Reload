using System.Collections.Generic;
using System.Web.Mvc;

namespace Reload.Web.Configuration
{
	/// <summary>The view enging configuration.</summary>
	public static class ViewEngineConfig
	{
		/// <summary>Registers the custom view engines.</summary>
		/// <param name="viewEngines">The view engines.</param>
		public static void RegisterCustomViewEngines(ICollection<IViewEngine> viewEngines)
		{
			string[] viewPaths = new string[]
			{
				"~/Views/{1}/{0}.cshtml",
				"~/Views/{0}.cshtml",
				"~/Views/Shared/{0}.cshtml"
			};

			string[] areaViewPaths = new string[]
			{
				"~/Areas/{2}/Views/{1}/{0}.cshtml",
				"~/Areas/{2}/Views/{0}.cshtml",
				"~/Areas/{2}/Views/Shared/{0}.cshtml"
			};

			// Remove web forms and vb view paths since this is a C# app and they slow things down.
			viewEngines.Clear();

			viewEngines.Add(new RazorViewEngine
			{
				PartialViewLocationFormats = viewPaths,
				ViewLocationFormats = viewPaths,
				AreaViewLocationFormats = areaViewPaths,
				AreaPartialViewLocationFormats = areaViewPaths
			});
		}
	}
}