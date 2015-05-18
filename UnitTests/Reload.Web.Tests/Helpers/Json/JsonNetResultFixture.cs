using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reload.Web.Helpers.Json;

namespace Reload.Web.Tests.Helpers.Json
{
	[TestClass]
	public class JsonNetResultFixture
	{
		[TestMethod]
		public void CanSerializeObject()
		{
			var testObject = new { Property = "value" };
			var jsonResult = new JsonNetResult(testObject);

			string response = TestHelper.GetJsonResultResponse(jsonResult);
			Assert.AreEqual("{\"Property\":\"value\"}", response);
		}

		[TestMethod]
		public void CanSerializeSimpleDictionary()
		{
			var testDictionary = new Dictionary<string, string>();
			testDictionary.Add("key", "value");

			var jsonResult = new JsonNetResult(testDictionary);

			string response = TestHelper.GetJsonResultResponse(jsonResult);
			Assert.AreEqual("{\"key\":\"value\"}", response);
		}

		[TestMethod]
		public void CanSerializeComplexDictionary()
		{
			var testDictionary = new Dictionary<string, object>();
			testDictionary.Add("key", new { key = "value" });

			var jsonResult = new JsonNetResult(testDictionary);

			string response = TestHelper.GetJsonResultResponse(jsonResult);
			Assert.AreEqual("{\"key\":{\"key\":\"value\"}}", response);
		}
	}

	public static class TestHelper
	{
		public static string GetJsonResultResponse(JsonResult jsonResult)
		{
			var httpContextMock = new Mock<HttpContextBase>();
			var httpResponseMock = new Mock<HttpResponseBase>();

			httpContextMock.Setup(x => x.Response).Returns(httpResponseMock.Object);

			var controllerContextMock = new Mock<ControllerContext>();
			controllerContextMock.Setup(x => x.HttpContext).Returns(httpContextMock.Object);

			string result = string.Empty;
			MemoryStream responseStream = new MemoryStream();

			TextWriter streamWriter = new StreamWriter(responseStream);

			httpResponseMock.Setup(x => x.Output)
				.Returns(streamWriter);

			jsonResult.ExecuteResult(controllerContextMock.Object);

			using(var streamReader = new StreamReader(responseStream))
			{
				result = streamReader.ReadToEnd();
			}

			return result;
		}
	}
}