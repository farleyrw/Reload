using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Reload.Common.Authentication;
using ReloadingApp.Authentication;
using ReloadingApp.Models;

namespace ReloadingApp.Controllers
{
	/// <summary>Base controller implementation.</summary>
	public abstract class BaseController : Controller
	{
		/// <summary>Initializes a new instance of the <see cref="BaseController"/> class.</summary>
		public BaseController() { }

		/// <summary>Initializes data that is not be available when the constructor is called.</summary>
		/// <param name="requestContext">The HTTP context and route data.</param>
		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);

			HttpCookie requestAuthCookie = requestContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
			if(requestAuthCookie != null)
			{
				requestAuthCookie.Expires = DateTime.Now.AddMinutes(requestContext.HttpContext.Session.Timeout);
				requestContext.HttpContext.Response.SetCookie(requestAuthCookie);
			}
		}

		/// <summary>Saves the authentication.</summary>
		/// <param name="userData">The user data.</param>
		protected void SaveAuthentication(UserIdentityData userData)
		{
			double authenticationTimeout = Convert.ToDouble(this.Session.Timeout);

			HttpCookie authorizationCookie = MvcAuthentication.GetAuthorizationCookie(userData, authenticationTimeout);

			if(authorizationCookie != null)
			{
				this.DeleteFormsAuthentication();

				this.Response.Cookies.Add(authorizationCookie);
			}
		}

		/// <summary>Deletes the forms authentication ticket.</summary>
		protected void DeleteFormsAuthentication()
		{
			FormsAuthentication.SignOut();
		}

		/// <summary>Logs out the user and removes authentication ticket.</summary>
		protected RedirectToRouteResult Logout()
		{
			this.DeleteFormsAuthentication();

			return this.RedirectToAction("Login", "Account");
		}

		/// <summary>Gets the JSON result.</summary>
		/// <param name="result">The result.</param>
		protected JsonResult GetJsonResult(object result)
		{
			return Json(result, JsonRequestBehavior.AllowGet);
		}

		/// <summary>Gets the JSON status result.</summary>
		/// <param name="success">if set to <c>true</c> [success].</param>
		/// <param name="message">The message.</param>
		protected JsonResult GetJsonStatusResult(bool success, string message)
		{
			return this.GetJsonResult(new JsonStatusResult { Success = success, Message = message });
		}

	}
}