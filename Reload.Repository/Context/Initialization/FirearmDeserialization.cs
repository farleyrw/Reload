using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Reload.Common.Models;

namespace Reload.Repository.Context.Initialization
{
	public static class FirearmDeserialization
	{
		public static Firearm GetData()
		{
			Firearm firearm = JsonConvert.DeserializeObject<Firearm>(
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