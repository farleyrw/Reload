using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Angular;

namespace Reload.Web.Tests.Helpers.Angular
{
	[TestClass]
	public class NgModelHelpersFixture
	{
		private static HtmlHelper<NgTestModel> TestHtmlHelper;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			TestHtmlHelper = HtmlHelperMockBetter.GetHtmlHelper<NgTestModel>(new NgTestModel());
		}

		[TestMethod]
		public void MustReturnElementWithRequiredAttribute()
		{
			string element = TestHtmlHelper.NgModelFor(s => s.RequiredProperty).ToString();

			Assert.IsTrue(element.StartsWith("<input"));

			Assert.IsTrue(element.Contains("required"));
		}
	}
}