using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Html;

namespace Reload.Web.Tests.Helpers.Html
{
	[TestClass]
	public class MaxlengthTextboFixture
	{
		private static HtmlHelper<TestModel> TestHtmlHelper;

		[ClassInitialize]
		public static void Initialize(TestContext testContext)
		{
			TestHtmlHelper = HtmlHelperMock.GetHtmlHelper<TestModel>(new TestModel());
		}

		[TestMethod]
		public void CanAddMaxlengthAttribute()
		{
			string result = TestHtmlHelper.MaxLengthTextBoxFor(x => x.MaxlengthField).ToString();

			Assert.IsTrue(result.Contains("maxlength=\"20\""));
		}

		[TestMethod]
		public void CanIgnoreMaxlengthAttribute()
		{
			string result = TestHtmlHelper.MaxLengthTextBoxFor(x => x.NoMaxlengthField).ToString();

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