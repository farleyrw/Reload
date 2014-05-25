using System.Net;
using System.Web.Mvc;

namespace Reload.Web.Attributes
{
	/// <summary>The custom ajax authorization attribute.</summary>
	public class AjaxAuthorizeAttribute : AuthorizeAttribute
	{
		/// <summary>Processes HTTP requests that fail authorization.</summary>
		/// <param name="filterContext">Encapsulates the information for using <see cref="T:System.Web.Mvc.AuthorizeAttribute" />. The <paramref name="filterContext" /> object contains the controller, HTTP context, request context, action result, and route data.</param>
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			var httpContext = filterContext.RequestContext.HttpContext;

			// TODO: Check if request is ajax and return 401 with specific json response.
			// http://stackoverflow.com/questions/2580596/how-do-you-handle-ajax-requests-when-user-is-not-authenticated
			if(httpContext.Request.IsAjaxRequest())
			{
				httpContext.Response.Clear();
				httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
				httpContext.Response.Write("The request is not authenticated");
				httpContext.Response.End();
			}
			else
			{
				base.HandleUnauthorizedRequest(filterContext);
			}
		}
	}
}