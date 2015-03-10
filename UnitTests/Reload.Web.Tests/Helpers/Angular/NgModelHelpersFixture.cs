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
			string element = TestHtmlHelper.NgTextBoxFor(s => s.SimpleProperty, new { @ng_model = "stuff", thing = "stuff" }).ToString();

			Assert.IsTrue(element.StartsWith("<input"));

			Assert.IsTrue(element.Contains(" type=\"text\" "));

			Assert.IsTrue(element.Contains(" thing=\"stuff\" "));

			Assert.IsTrue(element.Contains(" ng-model=\"stuff\" "));
		}

		[TestMethod]
		public void MustReturnElementWithRequiredAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.RequiredProperty).ToString();

			Assert.IsTrue(element.Contains(" required=\"\" "));
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
		public void MustReturnElementWithRangedAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.RangedProperty).ToString();

			Assert.IsTrue(element.Contains(" min=\"1\" "));

			Assert.IsTrue(element.Contains(" max=\"5\" "));
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

		[TestMethod]
		public void MustReturnElementWithNumericTypeAttribute()
		{
			string element = TestHtmlHelper.NgTextBoxFor(s => s.NumericProperty).ToString();

			Assert.IsTrue(element.Contains(" type=\"number\" "));
		}
	}
}