using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ReloadingApp.Helpers.Json
{
	/// <summary>The json deserialization helper.</summary>
	public static class JsonDeserializationHelper
	{
		/// <summary>Gets the data.</summary>
		/// <typeparam name="T"></typeparam>
		public static List<T> GetData<T>()
		{
			List<T> objects = JsonConvert.DeserializeObject<List<T>>(
				GetJsonFileData<T>(),
				new StringEnumConverter()
			);

			return objects;
		}

		/// <summary>Gets the json file data.</summary>
		/// <typeparam name="T"></typeparam>
		private static string GetJsonFileData<T>()
		{
			string objectTypeName = typeof(T).Name;
			string assemblyName = Assembly.GetExecutingAssembly().CodeBase;
			string assemblyPath = Uri.UnescapeDataString(new UriBuilder(assemblyName).Path);
			string filePath = Path.Combine(Path.GetDirectoryName(assemblyPath), 
				string.Format(@"App_Data\Initialization\Data\{0}.json", objectTypeName)
			);

			return File.ReadAllText(filePath);
		}
	}
}