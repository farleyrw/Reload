using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Helpers;
using Description = System.ComponentModel.DescriptionAttribute;

namespace Reload.Common.Tests.Helpers
{
	[TestClass]
	public class EnumHelperFixture
	{
		[TestMethod]
		public void EnumParse()
		{
			TestEnum testEnum = EnumHelper.Parse<TestEnum>("B");

			Assert.AreEqual(TestEnum.B, testEnum);
		}

		[TestMethod]
		public void EnumDescription()
		{
			string x = EnumHelper.Description<TestEnum>(TestEnum.B);

			Assert.AreEqual("B", x);
		}

		[TestMethod]
		public void EnumParseDescription()
		{
			TestEnum testEnum = EnumHelper.ParseDescription<TestEnum>("B");

			Assert.AreEqual(TestEnum.B, testEnum);
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

		[TestMethod]
		public void EnumCustomAttribute()
		{
			string x = EnumHelper.Stuff<TestCustomEnum, TestCustomAttribute>(TestCustomEnum.B);

			Assert.AreEqual(x, "B");
		}
	}

	public enum TestEnum
	{
		[Description("A")]
		A = 0,
		[Description("B")]
		B,
		[Description("C")]
		C
	}

	public enum TestCustomEnum
	{
		[TestCustomAttribute("A")]
		A = 0,
		[TestCustomAttribute("B")]
		B,
		[TestCustomAttribute("C")]
		C
	}

	public class TestCustomAttribute : Description
	{
		public TestCustomAttribute(string description) : base(description) { }
	}
}