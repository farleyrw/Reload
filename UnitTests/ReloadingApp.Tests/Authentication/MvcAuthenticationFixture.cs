using System;
using System.Web;
using System.Web.Security;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Authentication.Mvc;

namespace Reload.Common.Tests.Authentication
{
	[TestClass]
	public class MvcAuthenticationFixture
	{
		private static readonly CompareObjects comparer = new CompareObjects();

		private static UserIdentityData TestUserData = new UserIdentityData
		{
			AccountId = 1,
			Email = "user@person.com",
			FirstName = "Reloading",
			LastName = "User"
		};

		private static double TestTimeoutMinutes = 10;

		private static HttpCookie TestAuthorizationCookie
		{
			get { return MvcAuthentication.GetAuthorizationCookie(TestUserData, TestTimeoutMinutes); }
		}

		[TestMethod]
		public void GetAuthorizationCookieTest()
		{
			FormsAuthenticationTicket authorizationTicket = FormsAuthentication.Decrypt(TestAuthorizationCookie.Value);

			UserIdentity identity = new UserIdentity(authorizationTicket);

			double expectedTimeoutMinutes = DateTime.Compare(authorizationTicket.IssueDate, authorizationTicket.Expiration);

			Assert.AreEqual<DateTime>(
				authorizationTicket.IssueDate.AddMinutes(TestTimeoutMinutes),
				authorizationTicket.Expiration,
				"The expected timeout minutes do not match the actual.");
			Assert.IsTrue(comparer.Compare(TestUserData, identity.GetUserData()), comparer.DifferencesString);
		}

		[TestMethod]
		public void GetUserIdentityTest()
		{
			UserIdentity identity = MvcAuthentication.GetUserIdentity(TestAuthorizationCookie);

			Assert.IsTrue(comparer.Compare(TestUserData, identity.GetUserData()), comparer.DifferencesString);
		}
	}
}