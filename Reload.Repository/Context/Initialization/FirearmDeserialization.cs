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
		public static List<Firearm> GetData()
		{
			List<Firearm> firearm = JsonConvert.DeserializeObject<List<Firearm>>(
				File.ReadAllText(GetJsonFile()),
				new StringEnumConverter()
			);

			return firearm;
		}

		private static string GetJsonFile()
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			string path = Uri.UnescapeDataString(new UriBuilder(codeBase).Path);
			string x = Path.GetDirectoryName(path);

			return Path.Combine(x, @"Context\Initialization\Data.json");
		}
	}
}