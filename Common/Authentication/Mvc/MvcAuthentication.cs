using System;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Reload.Common.Authentication.Mvc
{
	/// <summary>The Mvc authentication class.</summary>
	public static class MvcAuthentication
	{
		/// <summary>Authenticates the user.</summary>
		/// <param name="user">The user.</param>
		public static void AuthenticateUser(IUserIdentity user)
		{
			SetAuthentication(user);
		}

		/// <summary>Signs out the user.</summary>
		public static void SignOut()
		{
			FormsAuthentication.SignOut();

			FormsAuthentication.RedirectToLoginPage();
		}

		/// <summary>Gets the current user.</summary>
		public static IUserIdentity GetUser()
		{
			if(HttpContext.Current.User.Identity is IUserIdentity)
			{
				return (UserIdentity)HttpContext.Current.User.Identity;
			}

			return new UserIdentity();
		}

		/// <summary>Handles the PostAuthenticateRequest event of the MvcApplication control.</summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		public static void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
		{
			if(!HttpContext.Current.Request.IsAuthenticated) { return; }

			UpdateUserExpiration();
		}

		/// <summary>Gets the authorization ticket.</summary>
		/// <param name="user">The user.</param>
		public static string GetAuthorizationTicket(IUserIdentity user)
		{
			FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
				version: 1,
				name: user.Name,
				issueDate: DateTime.Now,
				expiration: DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
				isPersistent: true,
				userData: new JavaScriptSerializer().Serialize(user)
			);

			return FormsAuthentication.Encrypt(authTicket);
		}

		/// <summary>Gets the user identity from encrypted ticket.</summary>
		/// <param name="encryptedTicket">The encrypted ticket.</param>
		public static IUserIdentity GetUserIdentityFromEncryptedTicket(string encryptedTicket)
		{
			FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encryptedTicket);

			return new JavaScriptSerializer().Deserialize<UserIdentity>(ticket.UserData);
		}

		/// <summary>Updates the user expiration.</summary>
		private static void UpdateUserExpiration()
		{
			IUserIdentity user = GetUserFromCookie();

			SetAuthentication(user);
		}

		/// <summary>Gets the ticket expiration.</summary>
		private static DateTime GetTicketExpiration()
		{
			return DateTime.Now.AddMinutes(FormsAuthentication.Timeout.Minutes);
		}

		/// <summary>Gets the user from cookie.</summary>
		private static IUserIdentity GetUserFromCookie()
		{
			HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

			if(authCookie == null) { return null; }

			string encryptedTicket = authCookie.Value;

			if(string.IsNullOrWhiteSpace(encryptedTicket)) { return null; }

			return GetUserIdentityFromEncryptedTicket(encryptedTicket);
		}

		/// <summary>Sets the authentication.</summary>
		/// <param name="user">The user.</param>
		private static void SetAuthentication(IUserIdentity user)
		{
			if(user == null) { return; }

			HttpContext.Current.User = new UserPrincipal(user);
			Thread.CurrentPrincipal = HttpContext.Current.User;

			string encryptedTicket = GetAuthorizationTicket(user);

			HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
			{
				Expires = GetTicketExpiration()
			};

			HttpContext.Current.Response.SetCookie(authCookie);
		}
	}
}