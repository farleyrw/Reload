using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Html;

namespace Reload.Web.Tests.Helpers.Html
{
	[TestClass]
	public class MaxlengthTextboFixture
	{
		[TestMethod]
		public void CanAddMaxlengthAttribute()
		{
			HtmlHelper<TestModel> html = HtmlHelperMock.GetHtmlHelper<TestModel>(new TestModel());
			string result = html.MaxLengthTextBoxFor(x => x.MaxlengthField).ToString();

			Assert.IsTrue(result.Contains("maxlength=\"20\""));
		}

		[TestMethod]
		public void CanSkipMaxlengthAttribute()
		{
			HtmlHelper<TestModel> html = HtmlHelperMock.GetHtmlHelper<TestModel>(new TestModel());
			string result = html.MaxLengthTextBoxFor(x => x.NoMaxlengthField).ToString();

			Assert.IsFalse(result.Contains("maxlength"));
		}
	}

	public class TestModel
	{
		[StringLength(20)]
		public string MaxlengthField { get; set; }

		public string NoMaxlengthField { get; set; }
	}
}