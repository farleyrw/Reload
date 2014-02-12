using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Authentication.Mvc;
using ReloadingApp.Controllers;

namespace ReloadingApp.Tests.Controllers
{
	[TestClass]
	public class BaseControllerFixture
	{
		[TestMethod]
		public void AssertAllControllersInheritFromBaseControllerTest()
		{
			IEnumerable<Type> x = typeof(BaseController).Assembly.GetTypes()
				.Where(type =>
					type.IsClass &&
					!type.IsSubclassOf(typeof(BaseController)) &&
					type.Name.EndsWith("Controller", StringComparison.InvariantCultureIgnoreCase) &&
					!type.Name.Equals("BaseController", StringComparison.InvariantCultureIgnoreCase));

			Assert.IsFalse(x.Any(), "Controllers exist that are not derived from BaseController.");
		}
	}

	/// <summary>A test controller to expose protected methods for testing.</summary>
	public class TestController : BaseController
	{
		/// <summary>Saves the authentication.</summary>
		/// <param name="userData">The user data.</param>
		public new void SaveAuthentication(UserIdentityData userData)
		{
			//base.SaveAuthentication(userData);
		}
	}
}