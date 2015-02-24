using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Angular;

namespace Reload.Web.Tests.Helpers.Angular
{
	[TestClass]
	public class NgValidationHelpersFixture
	{
		private static HtmlHelper<NgTestModel> TestHtmlHelper;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			TestHtmlHelper = HtmlHelperMock.GetHtmlHelper<NgTestModel>(new NgTestModel());
		}

		[TestMethod]
		public void MustReturnRequiredMessage()
		{
			string attributes = TestHtmlHelper.NgValidationMessagesFor(s => s.RequiredProperty).ToString();

			Assert.IsTrue(attributes.Contains("ng-message=\"required\""));
		}
	}
}