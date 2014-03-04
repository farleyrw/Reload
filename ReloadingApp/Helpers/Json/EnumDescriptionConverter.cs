using System;
using Newtonsoft.Json;
using Reload.Common.Attributes;
using Reload.Common.Helpers;

namespace ReloadingApp.Helpers.Json
{
	/// <summary>Firearm cartridge enum description converter.</summary>
	public class EnumDescriptionConverter<T> : JsonConverter where T : struct
	{
		/// <summary>Gets the enum value from the given description.</summary>
		/// <param name="description">The description.</param>
		public T ParseDescription(string description)
		{
			return EnumHelper.ParseDescription<T>(description);
		}

		/// <summary>Gets the description.</summary>
		/// <param name="enumValue">The enum value.</param>
		public string GetDescription(object enumValue)
		{
			return EnumHelper.Description<T>((T)enumValue);
		}

		/// <summary>Determines whether this instance can convert the specified object type.</summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
		public override bool CanConvert(Type objectType)
		{
			return Attribute.IsDefined(objectType, typeof(EnumDeserializeDescriptionAttribute), false);
		}

		/// <summary>Reads the JSON representation of the object.</summary>
		/// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			string description = reader.Value.ToString();

			return this.ParseDescription(description);
		}

		/// <summary>Writes the JSON representation of the object.</summary>
		/// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			string enumValue = this.GetDescription(value);

			serializer.Serialize(writer, enumValue);
		}
	}
}