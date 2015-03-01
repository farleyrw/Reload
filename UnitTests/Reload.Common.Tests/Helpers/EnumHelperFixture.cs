using System;
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
		public void Parse()
		{
			TestEnum testEnum = EnumHelper.Parse<TestEnum>("B");

			Assert.AreEqual(TestEnum.B, testEnum);
		}

		[TestMethod]
		public void Description()
		{
			string description = EnumHelper.Description<TestEnum>(TestEnum.B);

			Assert.AreEqual("B", description);
		}

		[TestMethod]
		public void ParseDescription()
		{
			TestEnum testEnum = EnumHelper.ParseDescription<TestEnum>("B");

			Assert.AreEqual(TestEnum.B, testEnum);
		}

		[TestMethod]
		public void Descriptions()
		{
			IDictionary<TestEnum, string> enums = EnumHelper.Descriptions<TestEnum>();

			Assert.AreEqual(3, enums.Count);
			Assert.AreEqual("A", enums[TestEnum.A]);
			Assert.AreEqual("B", enums[TestEnum.B]);
			Assert.AreEqual("C", enums[TestEnum.C]);
		}

		[TestMethod]
		public void DefaultValue()
		{
			TestEnum defaultEnum = EnumHelper.DefaultValue<TestEnum>();

			Assert.AreEqual(TestEnum.A, defaultEnum);
		}
		
		[TestMethod]
		public void ToList()
		{
			List<TestEnum> enums = EnumHelper.ToList<TestEnum>();

			Assert.AreEqual(3, enums.Count);
			Assert.AreEqual(TestEnum.A, enums[0]);
			Assert.AreEqual(TestEnum.B, enums[1]);
			Assert.AreEqual(TestEnum.C, enums[2]);
		}

		[TestMethod]
		public void ParseCustomDescription()
		{
			TestCustomEnum testEnum = EnumHelper.ParseCustomDescription<TestCustomEnum, TestCustomDescriptionAttribute>("2");

			Assert.AreEqual(TestCustomEnum.B, testEnum);
		}

		[TestMethod]
		public void CustomDescription()
		{
			string x = EnumHelper.CustomDescription<TestCustomEnum, TestCustomDescriptionAttribute>(TestCustomEnum.B);

			Assert.AreEqual("2", x);
		}

		[TestMethod]
		public void CustomDescriptions()
		{
			IDictionary<TestCustomEnum, string> enums = EnumHelper.CustomDescriptions<TestCustomEnum, TestCustomDescriptionAttribute>();

			Assert.AreEqual(3, enums.Count);
			Assert.AreEqual("1", enums[TestCustomEnum.A]);
			Assert.AreEqual("2", enums[TestCustomEnum.B]);
			Assert.AreEqual("3", enums[TestCustomEnum.C]);
		}

		[TestMethod]
		public void CustomAttributes()
		{
			List<TestEnum> enums = EnumHelper.CustomAttributes<TestEnum, TestCustomAttribute>();

			Assert.AreEqual(2, enums.Count);
		}
	}

	public enum TestEnum
	{
		[TestCustom]
		[Description("A")]
		A = 0,
		[Description("B")]
		B,
		[TestCustom]
		[Description("C")]
		C
	}

	public enum TestCustomEnum
	{
		[TestCustomDescription("1")]
		A = 0,
		[TestCustomDescription("2")]
		B,
		[TestCustomDescription("3")]
		C
	}

	public class TestCustomDescriptionAttribute : Description
	{
		public TestCustomDescriptionAttribute(string description) : base(description) { }
	}

	public class TestCustomAttribute : Attribute { }
}