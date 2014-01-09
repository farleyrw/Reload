using System;
using System.Web;
using System.Web.Security;
using Reload.Common.Authentication;
using Reload.Common.Helpers;

namespace ReloadingApp.Authentication
{
	/// <summary>The Mvc authentication.</summary>
	public class MvcAuthentication
	{
		/// <summary>Gets the authorization cookie.</summary>
		/// <param name="userData">The user data.</param>
		/// <param name="timeoutMinutes">The timeout minutes.</param>
		public static HttpCookie GetAuthorizationCookie(UserIdentityData userData, double timeoutMinutes)
		{
			FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
				1,
				UserIdentity.TicketName,
				DateTime.Now,
				DateTime.Now.AddMinutes(timeoutMinutes),
				true,
				XmlTransformHelper.ToXml(userData)
			);

			HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket))
			{
				Expires = authTicket.Expiration
			};

			return authCookie;
		}

		/// <summary>Gets the informz identity from the Shared Session Cookie value.</summary>
		/// <param name="authorizationCookie">The auth cookie.</param>
		public static UserIdentity GetUserIdentity(HttpCookie authorizationCookie)
		{
			if(authorizationCookie == null) { return null; }

			UserIdentity identity = new UserIdentity(FormsAuthentication.Decrypt(authorizationCookie.Value));

			return identity;
		}
	}
}