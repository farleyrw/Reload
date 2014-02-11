using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reload.Common.Models;

namespace Reload.Repository.Context.Initialization
{
	public static class FirearmDeserialization
	{
		public static List<Firearm> GetFirearmData()
		{
			List<Firearm> firearms = JsonConvert.DeserializeObject<List<Firearm>>(
				GetJsonData(),
				new StringEnumConverter()
			);

			return firearms;
		}

		private static string GetJsonData()
		{
			string assemblyName = Assembly.GetExecutingAssembly().CodeBase;
			string assemblyPath = Uri.UnescapeDataString(new UriBuilder(assemblyName).Path);
			string filePath = Path.Combine(Path.GetDirectoryName(assemblyPath), @"Context\Initialization\Data.json");

			return File.ReadAllText(filePath);
		}
	}
}