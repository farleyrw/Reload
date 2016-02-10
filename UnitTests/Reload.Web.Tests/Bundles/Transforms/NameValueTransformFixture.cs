using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Bundles.Transforms;

namespace Reload.Web.Tests.Bundles.Transforms
{
	[TestClass]
	public class NameValueTransformFixture
	{
		[TestMethod]
		public void CanTransformNameValue()
		{
			string testSetting = "TestSetting";
			string testValue = "value";

			NameValueCollection settings = new NameValueCollection();
			settings.Add(testSetting, testValue);

			NameValueBundleTransform configTransform = new NameValueBundleTransform(settings, testSetting);

			string scriptContent = "var x = '{" + testSetting + "}';";

			string result = configTransform.Process(string.Empty, scriptContent);

			Assert.AreEqual(result, "var x = '" + testValue + "';");
		}
	}
}