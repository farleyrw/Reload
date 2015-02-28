using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Angular;

namespace Reload.Web.Tests.Helpers.Angular
{
	[TestClass]
	public class NgValidationMessageHelpersFixture
	{
		private static HtmlHelper<NgTestModel> TestHtmlHelper;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			TestHtmlHelper = HtmlHelperMockBetter.GetHtmlHelper<NgTestModel>(new NgTestModel());
		}

		[TestMethod]
		public void MustReturnRequiredValidationMessage()
		{
			string messages = TestHtmlHelper.NgValidationMessagesFor(s => s.RequiredProperty).ToString();

			Assert.IsTrue(messages.Contains("ng-message=\"required\""));
		}

		[TestMethod]
		public void MustReturnMaxlengthValidationMessage()
		{
			string messages = TestHtmlHelper.NgValidationMessagesFor(s => s.MaxLength10Property).ToString();

			Assert.IsTrue(messages.Contains("ng-message=\"maxlength\""));
		}

		[TestMethod]
		public void MustReturnMinAndMaxlengthValidationMessage()
		{
			string messages = TestHtmlHelper.NgValidationMessagesFor(s => s.Between5And10Property).ToString();

			Assert.IsTrue(messages.Contains("ng-message=\"maxlength\""));
			Assert.IsTrue(messages.Contains("ng-message=\"minlength\""));
		}

		[TestMethod]
		public void MustReturnPatternValidationMessage()
		{
			string messages = TestHtmlHelper.NgValidationMessagesFor(s => s.PatternProperty).ToString();

			Assert.IsTrue(messages.Contains("ng-message=\"pattern\""));
		}

		[TestMethod]
		public void MustReturnEmailValidationMessage()
		{
			string messages = TestHtmlHelper.NgValidationMessagesFor(s => s.EmailProperty).ToString();

			Assert.IsTrue(messages.Contains("ng-message=\"email\""));
		}

		[TestMethod]
		public void MustReturnCustomErrorValidationMessage()
		{
			string messages = TestHtmlHelper.NgValidationMessagesFor(s => s.CustomErrorMessageProperty).ToString();

			Assert.IsTrue(messages.Contains(">Custom error message</"));
		}
	}
}