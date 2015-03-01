using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Angular;

namespace Reload.Web.Tests.Helpers.Angular
{
	[TestClass]
	public class NgModelDirectiveHelpersFixture
	{
		private static HtmlHelper<NgTestModel> TestHtmlHelper;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			TestHtmlHelper = HtmlHelperMock.GetHtmlHelper<NgTestModel>(new NgTestModel());
		}

		[TestMethod]
		public void MustReturnRequiredAttribute()
		{
			string attributes = TestHtmlHelper.NgValidationAttributesFor(s => s.RequiredProperty).ToString();

			Assert.IsTrue(attributes.Contains("required"));
			Assert.IsFalse(attributes.Contains("required="));
		}

		[TestMethod]
		public void MustReturnNgMaxlengthAttribute()
		{
			string attributes = TestHtmlHelper.NgValidationAttributesFor(s => s.MaxLength10Property).ToString();

			Assert.IsTrue(attributes.Contains("ng-maxlength=\"10\""));
		}

		[TestMethod]
		public void MustReturnNgMinAndMaxlengthAttributes()
		{
			string attributes = TestHtmlHelper.NgValidationAttributesFor(s => s.Between5And10Property).ToString();

			Assert.IsTrue(attributes.Contains("ng-minlength=\"5\""));
			Assert.IsTrue(attributes.Contains("ng-maxlength=\"10\""));
		}

		[TestMethod]
		public void MustReturnNgPatternAttribute()
		{
			string attributes = TestHtmlHelper.NgValidationAttributesFor(s => s.PatternProperty).ToString();

			Assert.IsTrue(attributes.Contains("ng-pattern=\"\\d\""));
		}

		[TestMethod]
		public void MustReturnMultipleNgAttributes()
		{
			string attributes = TestHtmlHelper.NgValidationAttributesFor(s => s.MultipleValidationProperty).ToString();

			Assert.IsTrue(attributes.Contains("required"));

			Assert.IsTrue(attributes.Contains("ng-maxlength=\"5\""));
		}

		[TestMethod]
		public void MustReturnNgRangeAttributes()
		{
			string attributes = TestHtmlHelper.NgValidationAttributesFor(s => s.RangedProperty).ToString();

			Assert.IsTrue(attributes.Contains("min=\"1\""));

			Assert.IsTrue(attributes.Contains("max=\"5\""));
		}
	}
}