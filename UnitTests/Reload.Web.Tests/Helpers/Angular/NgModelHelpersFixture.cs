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
			TestHtmlHelper = HtmlHelperMock.GetHtmlHelper<NgTestModel>(new NgTestModel());
		}

		[TestMethod]
		public void MustReturnSimpleElement()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.SimpleProperty).ToString();

			Assert.IsTrue(element.StartsWith("<input"));

			Assert.IsTrue(element.Contains("type=\"text\""));
		}

		[TestMethod]
		public void MustReturnElementWithRequiredAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.RequiredProperty).ToString();

			Assert.IsTrue(element.Contains("required"));
		}

		[TestMethod]
		public void MustReturnElementWithMaxlengthAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.MaxLength10Property).ToString();

			Assert.IsTrue(element.Contains("ng-maxlength=\"10\""));
		}

		[TestMethod]
		public void MustReturnElementWithMinAndMaxlengthAttributes()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.Between5And10Property).ToString();

			Assert.IsTrue(element.Contains(" ng-minlength=\"5\" "));

			Assert.IsTrue(element.Contains(" ng-maxlength=\"10\" "));
		}

		[TestMethod]
		public void MustReturnElementWithPatternAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.PatternProperty).ToString();

			Assert.IsTrue(element.Contains("ng-pattern=\"\\d\""));
		}

		[TestMethod]
		public void MustReturnElementWithMultipleAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.MultipleValidationProperty).ToString();

			Assert.IsTrue(element.Contains(" required=\"\" "));

			Assert.IsTrue(element.Contains(" ng-maxlength=\"5\" "));
		}

		[TestMethod]
		public void MustReturnElementWithEmailTypeAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.EmailProperty).ToString();

			Assert.IsTrue(element.Contains(" type=\"email\" "));
		}

		[TestMethod]
		public void MustReturnElementWithDateTypeAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.DateProperty).ToString();

			Assert.IsTrue(element.Contains(" type=\"date\" "));
		}
	}
}