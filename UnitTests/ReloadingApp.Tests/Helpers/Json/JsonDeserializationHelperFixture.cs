using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReloadingApp.Helpers.Json;

namespace ReloadingApp.Tests.Helpers.Json
{
	[TestClass]
	public class JsonDeserializationHelperFixture
	{
		[TestMethod]
		public void CanDeserializeObjectList()
		{
			List<TestThing> expectedList = new List<TestThing> { new TestThing { Name = "Bleh", Enum = TestEnum.B } };
			List<TestThing> deserializedList = JsonDeserializationHelper.GetData<TestThing>();

			Assert.AreEqual(expectedList.Count, deserializedList.Count);
			Assert.AreEqual(expectedList[0].Enum, deserializedList[0].Enum);
			Assert.AreEqual(expectedList[0].Name, deserializedList[0].Name);
			//Assert.AreEqual<TestThing>(expectedList[0], deserializedList[0]);
			//CollectionAssert.AreEqual(expectedList, deserializedList);
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