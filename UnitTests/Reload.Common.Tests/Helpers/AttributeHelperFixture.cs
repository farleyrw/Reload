using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Helpers;

namespace Reload.Common.Tests.Helpers
{
	[TestClass]
	public class AttributeHelperFixture
	{
		[TestMethod]
		public void PropertyHasAttributeTest()
		{
			bool propertyHasAttribute = AttributeHelper.PropertyHasAttribute<LOLAttribute>(LOLEnum.B);

			Assert.IsTrue(propertyHasAttribute);
		}

		[TestMethod]
		public void PropertyDoesNotHaveAttributeTest()
		{
			bool propertyHasAttribute = AttributeHelper.PropertyHasAttribute<LOLAttribute>(LOLEnum.A);

			Assert.IsFalse(propertyHasAttribute);
		}
	}

	public enum LOLEnum
	{
		A,
		[LOL]
		B,
		C
	}

	public class LOLAttribute : Attribute { }
}