using System.Collections.Generic;
using KellermanSoftware.CompareNetObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Helpers.Json;

namespace Reload.Web.Tests.Helpers.Json
{
	[TestClass]
	public class JsonDeserializationHelperFixture
	{
		[TestMethod]
		public void CanDeserializeObjectList()
		{
			List<TestThing> expectedList = new List<TestThing> { new TestThing { Name = "Bleh", Enum = TestEnum.B } };
			List<TestThing> deserializedList = JsonDeserializationHelper.GetData<TestThing>();

			CompareLogic comparer = new CompareLogic();
			ComparisonResult result = comparer.Compare(expectedList, deserializedList);
			Assert.IsTrue(result.AreEqual, result.DifferencesString);
		}
	}

	public class TestThing
	{
		public string Name { get; set; }

		public TestEnum Enum { get; set; }

		public TestThing()
		{
			this.Name = "Name";
			this.Enum = TestEnum.A;
		}
	}

	public enum TestEnum
	{
		A,
		B
	}
}