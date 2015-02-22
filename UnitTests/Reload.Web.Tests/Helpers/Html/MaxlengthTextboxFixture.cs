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
			HtmlHelper<TestModel> html = HtmlHelperFactory.Create<TestModel>(new TestModel { Field = "lol" });
			string result = html.MaxLengthTextBoxFor(x => x.Field).ToString();

			Assert.IsTrue(result.Contains("maxlength=\"20\""));
		}
	}

	public class TestModel
	{
		[StringLength(20)]
		public string Field { get; set; }
	}
}