using System.Web.Mvc;

namespace ReloadingApp.Attributes
{
	public class AjaxAuthorizeAttribute : AuthorizeAttribute
	{
		protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
		{
			// TODO: Check if request is ajax and return 403 with specific json response.
			// http://stackoverflow.com/questions/2580596/how-do-you-handle-ajax-requests-when-user-is-not-authenticated
			base.HandleUnauthorizedRequest(filterContext);
		}
	}
}