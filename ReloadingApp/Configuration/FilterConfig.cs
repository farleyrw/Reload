using System.Web.Mvc;
using Informz.Web.App.Attributes;

namespace ReloadingApp.Configuration
{
	/// <summary>The base filter configuration for the application.</summary>
	public class FilterConfig
	{
		/// <summary>Registers the global filters.</summary>
		/// <param name="filters">The filters.</param>
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleExceptionAttribute());
			filters.Add(new AuthorizeAttribute());
		}
	}
}