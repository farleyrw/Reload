using System;
using System.Reflection;

namespace Reload.Common.Helpers
{
	/// <summary>The attribute helper class.</summary>
	public static class AttributeHelper
	{
		/// <summary>Determines whether the specified property has attribute.</summary>
		/// <param name="attribute">The attribute.</param>
		public static bool PropertyHasAttribute<TA>(object value) where TA : Attribute
		{
			FieldInfo propertyInfo = value.GetType().GetField(value.ToString());

			Attribute attribute = propertyInfo.GetCustomAttribute<TA>(false);

			return attribute != null;
		}
	}
}