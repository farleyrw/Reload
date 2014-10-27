using System;
using System.Web;
using System.Web.Security;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Authentication.Mvc;
using Reload.Common.Helpers;

namespace Reload.Common.Tests.Authentication
{
	[TestClass]
	public class MvcAuthenticationFixture
	{
		private static readonly CompareLogic comparer = new CompareLogic();

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
			get
			{
				string stringUserData = XmlTransformHelper.Serialize(TestUserData);
				return MvcAuthentication.GetAuthorizationCookie(stringUserData, TestTimeoutMinutes);
			}
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
			ComparisonResult result = comparer.Compare(TestUserData, identity.GetUserData());
			Assert.IsTrue(result.AreEqual, result.DifferencesString);
		}

		[TestMethod]
		public void GetUserIdentityTest()
		{
			UserIdentity identity = MvcAuthentication.GetUserIdentity(TestAuthorizationCookie);

			ComparisonResult result = comparer.Compare(TestUserData, identity.GetUserData());
			Assert.IsTrue(result.AreEqual, result.DifferencesString);
		}
	}
}