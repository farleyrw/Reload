using System.Web.Mvc;
using Reload.Web.Attributes;

namespace Reload.Web.Configuration
{
	/// <summary>The base filter configuration for the application.</summary>
	public static class FilterConfig
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