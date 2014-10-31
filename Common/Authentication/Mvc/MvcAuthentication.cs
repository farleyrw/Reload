using System;
using System.Web;
using System.Web.Security;
using Reload.Common.Helpers;

namespace Reload.Common.Authentication.Mvc
{
	/// <summary>The Mvc authentication class.</summary>
	public static class MvcAuthentication
	{
		/// <summary>Gets the authorization cookie.</summary>
		/// <param name="userData">The user data.</param>
		public static HttpCookie GetAuthorizationCookie(UserIdentityData userData)
		{
			FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
				version: 1,
				name: UserIdentity.TicketName,
				issueDate: DateTime.Now,
				expiration: DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
				isPersistent: true,
				userData: XmlTransformHelper.Serialize(userData)
			);

			HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket))
			{
				Expires = authTicket.Expiration
			};

			return authCookie;
		}

		/// <summary>Gets the identity from the authorization cookie value.</summary>
		public static UserIdentity GetUserIdentity()
		{
			HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

			return GetUserIdentity(authCookie);
		}

		/// <summary>Gets the identity from the authorization cookie value.</summary>
		/// <param name="authorizationCookie">The auth cookie.</param>
		public static UserIdentity GetUserIdentity(HttpCookie authorizationCookie)
		{
			if(authorizationCookie == null) { return null; }

			UserIdentity identity = new UserIdentity(FormsAuthentication.Decrypt(authorizationCookie.Value));

			return identity;
		}
	}
}