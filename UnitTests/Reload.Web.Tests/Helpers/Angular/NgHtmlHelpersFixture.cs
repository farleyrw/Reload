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
		[TestMethod]
		public void MustReturnRequiredClientValidationMessage()
		{
			HtmlHelper<TestEntity> html = null;
			var result = html.NgDirectivesFor(s => s.RequiredProperty);
			var expectedValue = "";// "ngval='{\"required\":\"The RequiredProperty field is required.\"}' required";

			Assert.AreEqual(expectedValue, result.ToString());
		}

		[TestMethod]
		public void MustReturnStringLength10ClientValidationMessage()
		{
			HtmlHelper<TestEntity> html = null;
			var result = html.NgDirectivesFor(s => s.Length10Property);
			var expectedValue = "";// "ngval='{\"length\":\"The field Length10Property must be a string with a maximum length of 10.\"}' ng-maxlength=\"10\"";
			
			Assert.AreEqual(expectedValue, result.ToString());
		}

		[TestMethod]
		public void MustReturnCombinedResultForRequiredAndPatternValidation()
		{
			HtmlHelper<TestEntity> html = null;
			var resultStr = html.NgDirectivesFor(s => s.MultipleValidationProperty).ToString();
			var expectedValue = "";// "ngval='{\"regex\":\"The field MultipleValidationProperty must match the regular expression \\u0027\\\\d\\u0027.\",\"required\":\"The MultipleValidationProperty field is required.\"}' ng-pattern=\"\\d\" required";
			
			Assert.AreEqual(expectedValue, resultStr);
		}
	}

	public class TestEntity
	{
		[Required]
		public string RequiredProperty { get; set; }

		[StringLength(10)]
		public string Length10Property { get; set; }

		[Required]
		[RegularExpression("\\d")]
		public string MultipleValidationProperty { get; set; }
	}
}
