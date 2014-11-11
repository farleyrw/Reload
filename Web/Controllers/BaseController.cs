using System.Web.Mvc;
using System.Web.Security;
using Reload.Common.Authentication.Mvc;
using Reload.Web.Models;

namespace Reload.Web.Controllers
{
	/// <summary>Base controller implementation.</summary>
	public abstract class BaseController : Controller
	{
		/// <summary>Gets the identity.</summary>
		/// <value>The identity.</value>
		protected IUserIdentity Identity { get { return this.User.Identity as UserIdentity; } }

		/// <summary>Logs out the user.</summary>
		protected void Logout()
		{
			MvcAuthentication.SignOut();
		}

		/// <summary>Gets the JSON result.</summary>
		/// <param name="result">The result.</param>
		public static JsonResult GetJsonResult(object result)
		{
			return new JsonResult { Data = result, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		/// <summary>Gets the JSON status result.</summary>
		/// <param name="success">if set to <c>true</c> [success].</param>
		/// <param name="message">The message.</param>
		public static JsonResult GetJsonStatusResult(bool success, object message = null)
		{
			return GetJsonResult(new JsonStatusResult { Success = success, Message = message });
		}
	}
}