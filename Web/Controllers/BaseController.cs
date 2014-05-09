using MvcContrib;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Reload.Common.Authentication.Mvc;
using Reload.Web.Models;

namespace Reload.Web.Controllers
{
	/// <summary>Base controller implementation.</summary>
	public abstract class BaseController : Controller
	{
		protected UserIdentity Identity
		{
			get
			{
				return (UserIdentity)this.User.Identity;
			}
		}

		/// <summary>Initializes data that is not be available when the constructor is called.</summary>
		/// <param name="requestContext">The HTTP context and route data.</param>
		protected override void Initialize(RequestContext requestContext)
		{
			base.Initialize(requestContext);

			HttpCookie requestAuthCookie = requestContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
			if(requestAuthCookie != null)
			{
				requestAuthCookie.Expires = DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes);
				requestContext.HttpContext.Response.SetCookie(requestAuthCookie);
			}
		}

		/// <summary>Saves the authentication.</summary>
		/// <param name="userData">The user data.</param>
		protected void SaveAuthentication(UserIdentityData userData)
		{
			double authenticationTimeout = FormsAuthentication.Timeout.TotalMinutes;

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

			return this.RedirectToAction<AccountController>(c => c.Login(null));
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