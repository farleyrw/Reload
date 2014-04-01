using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Reload.Web.Helpers.Json
{
	/// <summary>The json deserialization helper.</summary>
	public static class JsonDeserializationHelper
	{
		/// <summary>Gets the data.</summary>
		/// <typeparam name="T"></typeparam>
		public static List<T> GetData<T>()
		{
			return GetData<T>(new StringEnumConverter());
		}

		/// <summary>Gets the data.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonConverter">The json converter.</param>
		public static List<T> GetData<T>(JsonConverter jsonConverter)
		{
			List<T> objects = JsonConvert.DeserializeObject<List<T>>(
				GetJsonFileData<T>(),
				jsonConverter,
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
				string.Format(
					@"{0}\{1}.json",
					ConfigurationManager.AppSettings["TestDataInitializationPath"],
					objectTypeName
				)
			);

			return File.ReadAllText(filePath);
		}
	}
}