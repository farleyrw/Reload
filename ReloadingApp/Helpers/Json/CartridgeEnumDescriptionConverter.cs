using System;
using Newtonsoft.Json;
using Reload.Common.Enums;
using Reload.Common.Helpers;

namespace ReloadingApp.Helpers.Json
{
	public class CartridgeEnumDescriptionConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Cartridge);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return EnumHelper.ParseDescription<Cartridge>(existingValue.ToString());
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			string enumValue = EnumHelper.Description<Cartridge>((Cartridge)value);

			serializer.Serialize(writer, enumValue);
		}
	}
}