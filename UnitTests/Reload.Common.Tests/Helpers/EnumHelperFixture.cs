using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Helpers;

namespace Reload.Common.Tests.Helpers
{
	[TestClass]
	public class EnumHelperFixture
	{
		[TestMethod]
		public void EnumParse()
		{
			TestEnum testEnum = EnumHelper.Parse<TestEnum>("A");

			Assert.AreEqual(TestEnum.A, testEnum);
		}

		[TestMethod]
		public void EnumDescription()
		{
			string x = EnumHelper.Description<TestEnum>(TestEnum.A);

			Assert.AreEqual("A", x);
		}

		[TestMethod]
		public void EnumParseDescription()
		{
			TestEnum testEnum = EnumHelper.ParseDescription<TestEnum>("A");

			Assert.AreEqual(TestEnum.A, testEnum);
		}

		[TestMethod]
		public void EnumDescriptions()
		{
			IDictionary<TestEnum, string> enums = EnumHelper.Descriptions<TestEnum>();

			Assert.AreEqual(3, enums.Count);
		}

		[TestMethod]
		public void EnumDefaultValue()
		{
			TestEnum defaultEnum = EnumHelper.DefaultValue<TestEnum>();

			Assert.AreEqual(TestEnum.A, defaultEnum);
		}
		
		[TestMethod]
		public void EnumToList()
		{
			List<TestEnum> enums = EnumHelper.ToList<TestEnum>();

			Assert.AreEqual(TestEnum.A, enums[0]);
			Assert.AreEqual(TestEnum.B, enums[1]);
			Assert.AreEqual(TestEnum.C, enums[2]);
		}
	}
}