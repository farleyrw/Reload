using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Reload.Common.Helpers
{
	/// <summary>Enum helper class.</summary>
	public static class EnumHelper
	{
		/// <summary>Returns the enum value of the specified string value.</summary>
		/// <typeparam name="T">The type of the enum.</typeparam>
		/// <param name="value">The value.</param>
		/// <remarks>
		/// If the given value does not exist in the enum, the <see cref="DefaultValueAttribute"/> is checked for.
		/// If the default value attribute is not used, then the Zero value of the enum is returned.
		/// If there are no enum values defined to be Zero, the First item of the enum is returned.
		/// </remarks>
		public static T Parse<T>(string value) where T : struct
		{
			Type enumType = typeof(T);

			// Enum.TryParse doesn't take a generic type :(
			// and Enum.IsDefined checks the enum values by data type.
			// i.e. Evaluates to false when passing in "1" (string) to trying to see if the One = 1 value exists.
			int i;
			if(int.TryParse(value, out i))
			{
				if(Enum.IsDefined(enumType, i))
				{
					return (T)Enum.Parse(enumType, i.ToString(), false);
				}
			}

			if(Enum.IsDefined(enumType, value))
			{
				return (T)Enum.Parse(enumType, value);
			}

			// Read default value.
			var customAttribute = typeof(T).GetCustomAttributes<DefaultValueAttribute>(false);
			if(customAttribute.Any())
			{
				return Parse<T>(customAttribute.First().Value.ToString());
			}

			return default(T);
		}

		/// <summary>Parses the <see cref="DescriptionAttribute"/> to return the enum value.</summary>
		/// <typeparam name="T">The type of the enum.</typeparam>
		/// <param name="descriptionValue">The <see cref="DescriptionAttribute"/> value.</param>
		public static T ParseDescription<T>(string descriptionValue) where T : struct
		{
			IDictionary<T, string> descriptions = Descriptions<T>();

			KeyValuePair<T, string> keyValuePair = descriptions
				.FirstOrDefault(v => v.Value.Equals(descriptionValue, StringComparison.OrdinalIgnoreCase));

			return keyValuePair.Key;
		}

		/// <summary>Gets the <see cref="DescriptionAttribute"/> of the value.</summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="value">The value.</param>
		public static string Description<T>(T value) where T : struct
		{
			FieldInfo enumField = value.GetType().GetField(value.ToString());

			var attribute = enumField.GetCustomAttributes<DescriptionAttribute>(false);

			return attribute.Any()
					? attribute.First().Description
					: value.ToString();
		}

		/// <summary>Returns a dictionary of the enum with the type as the key, and description as the value.</summary>
		/// <typeparam name="T">The type of the enum.</typeparam>
		public static IDictionary<T, string> Descriptions<T>() where T : struct
		{
			Dictionary<T, string> result = new Dictionary<T, string>();

			foreach(string name in Enum.GetNames(typeof(T)))
			{
				T value = Parse<T>(name);
				string description = Description(value);

				result.Add(value, description);
			}

			return result;
		}

		/// <summary>Gets the default enum value, checking the attribute first.</summary>
		/// <typeparam name="T">The type of the enum.</typeparam>
		public static T DefaultValue<T>() where T : struct
		{
			var attributes = typeof(T).GetCustomAttributes<DefaultValueAttribute>(false);

			return attributes.Any()
				? (T)attributes.First().Value
				: default(T);
		}

		/// <summary>Returns a list of enum values.</summary>
		/// <typeparam name="T">The type of the enum.</typeparam>
		public static List<T> ToList<T>() where T : struct
		{
			return Enum.GetValues(typeof(T)).Cast<T>().ToList();
		}
	}
}