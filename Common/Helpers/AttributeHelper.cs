using System;
using System.Reflection;

namespace Reload.Common.Helpers
{
	/// <summary>The attribute helper class.</summary>
	public static class AttributeHelper
	{
		/// <summary>Determines whether the specified property has attribute.</summary>
		/// <param name="value">The value.</param>
		public static bool PropertyHasAttribute<TAttribute>(object value) where TAttribute : Attribute
		{
			FieldInfo propertyInfo = value.GetType().GetField(value.ToString());

			Attribute attribute = propertyInfo.GetCustomAttribute<TAttribute>(false);

			return attribute != null;
		}
	}
}