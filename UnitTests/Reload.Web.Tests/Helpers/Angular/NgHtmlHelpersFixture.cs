using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Angular;

namespace Reload.Web.Tests.Helpers.Angular
{
	// TODO: make these test the helper.
	[TestClass]
	public class NgHtmlHelpersFixture
	{
		private static HtmlHelper<TestModel> TestHtmlHelper;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			TestHtmlHelper = HtmlHelperMock.GetHtmlHelper<TestModel>(new TestModel());
		}

		[TestMethod]
		public void MustReturnRequiredAttribute()
		{
			string result = TestHtmlHelper.NgDirectivesFor(s => s.RequiredProperty).ToString();

			Assert.IsTrue(result.Contains("required"));
			Assert.IsFalse(result.Contains("required="));
		}

		[TestMethod]
		public void MustReturnNgMaxlengthAttribute()
		{
			string result = TestHtmlHelper.NgDirectivesFor(s => s.Length10Property).ToString();

			Assert.IsTrue(result.Contains("ng-maxlength=\"10\""));
		}

		[TestMethod]
		public void MustReturnNgPatternAttribute()
		{
			string result = TestHtmlHelper.NgDirectivesFor(s => s.PatternProperty).ToString();

			Assert.IsTrue(result.Contains("ng-pattern=\"\\d\""));
		}

		[TestMethod]
		public void MustReturnMultipleNgAttributes()
		{
			string result = TestHtmlHelper.NgDirectivesFor(s => s.MultipleValidationProperty).ToString();

			Assert.IsTrue(result.Contains("required"));

			Assert.IsTrue(result.Contains("ng-maxlength=\"5\""));
		}
	}

	public class TestModel
	{
		[Required]
		public string RequiredProperty { get; set; }

		[StringLength(10)]
		public string Length10Property { get; set; }

		[RegularExpression("\\d")]
		public string PatternProperty { get; set; }

		[Required]
		[StringLength(5)]
		public string MultipleValidationProperty { get; set; }
	}
}