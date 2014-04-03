using System.Collections.Generic;
using System.Web.Mvc;

namespace Reload.Web.Configuration
{
	/// <summary>The view enging configuration.</summary>
	public static class ViewEngineConfig
	{
		/// <summary>Registers the custom view engines.</summary>
		/// <param name="engines">The engines.</param>
		public static void RegisterCustomViewEngines(ICollection<IViewEngine> engines)
		{
			// Remove web forms and vb view paths.  This is c# mvc all the way.
			engines.Clear();

			string[] viewPaths = new string[]
			{
				"~/Views/{0}.cshtml",
				"~/Views/Shared/{0}.cshtml",
				"~/Views/{1}/{0}.cshtml"
			};

			string[] areaViewPaths = new string[]
			{
				"~/Areas/{2}/Views/{0}.cshtml",
				"~/Areas/{2}/Views/{1}/{0}.cshtml",
				"~/Areas/{2}/Views/Shared/{0}.cshtml"
			};

			engines.Add(new RazorViewEngine
			{
				PartialViewLocationFormats = viewPaths,
				ViewLocationFormats = viewPaths,
				AreaViewLocationFormats = areaViewPaths,
				AreaPartialViewLocationFormats = areaViewPaths
			});
		}
	}
}