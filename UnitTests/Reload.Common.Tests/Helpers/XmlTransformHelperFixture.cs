using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Helpers;

namespace Reload.Common.Tests.Helpers
{
	[TestClass]
	public class XmlTransformHelperFixture
	{
		[TestMethod]
		public void SerializeToXml()
		{
			TestClass testObject = new TestClass { TestField = "abc", TestNumber = 123 };

			string xmlObject = XmlTransformHelper.Serialize(testObject);
			
			Assert.IsTrue(xmlObject.Contains(@"<TestClass"));
			Assert.IsTrue(xmlObject.Contains(@"<TestField>abc</TestField>"));
			Assert.IsTrue(xmlObject.Contains(@"<TestNumber>123</TestNumber>"));
			Assert.IsTrue(xmlObject.Contains(@"</TestClass>"));
		}
		
		[TestMethod]
		public void DeserializeToObject()
		{
			string xmlObject = @"<?xml version=""1.0""?>
				<TestClass>
					<TestField>abc</TestField>
					<TestNumber>123</TestNumber>
				</TestClass>";

			TestClass testObject = XmlTransformHelper.Deserialize<TestClass>(xmlObject);

			Assert.AreEqual("abc", testObject.TestField);
			Assert.AreEqual(123, testObject.TestNumber);
		}
	}

	public class TestClass
	{
		public string TestField { get; set; }

		public int TestNumber { get; set; }
	}
}
