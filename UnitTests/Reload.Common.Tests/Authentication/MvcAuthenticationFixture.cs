using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Authentication.Mvc;

namespace Reload.Common.Tests.Authentication
{
	[TestClass]
	public class MvcAuthenticationFixture
	{
		[TestInitialize]
		public void Init()
		{
			// Mock up the http context so the tests will work.
			HttpContext.Current = new HttpContext(new HttpRequest(null, "http://tempuri.org", null), new HttpResponse(null));
		}

		private static IUserIdentity TestUserData = new UserIdentity
		{
			AccountId = 1,
			Email = "user@person.com",
			FirstName = "Reloading",
			LastName = "User"
		};

		[TestMethod]
		public void SetAuthorizationTest()
		{
			MvcAuthentication.AuthenticateUser(TestUserData);

			IUserIdentity userIdentity = HttpContext.Current.User.Identity as UserIdentity;

			Assert.AreEqual<int>(TestUserData.AccountId, userIdentity.AccountId);
			Assert.AreEqual<string>(TestUserData.Email, userIdentity.Email);
			Assert.AreEqual<string>(TestUserData.FirstName, userIdentity.FirstName);
			Assert.AreEqual<string>(TestUserData.LastName, userIdentity.LastName);
		}

		[TestMethod]
		public void GetUserIdentityTest()
		{
			string authTicket = MvcAuthentication.GetAuthorizationTicket(TestUserData);

			IUserIdentity userIdentity = MvcAuthentication.GetUserIdentityFromEncryptedTicket(authTicket);

			Assert.AreEqual<int>(TestUserData.AccountId, userIdentity.AccountId);
			Assert.AreEqual<string>(TestUserData.Email, userIdentity.Email);
			Assert.AreEqual<string>(TestUserData.FirstName, userIdentity.FirstName);
			Assert.AreEqual<string>(TestUserData.LastName, userIdentity.LastName);
		}
	}
}