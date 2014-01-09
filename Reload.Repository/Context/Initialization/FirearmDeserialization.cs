using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using Reload.Common.Models;

namespace Reload.Repository.Context.Initialization
{
	public static class FirearmDeserialization
	{
		public static List<Firearm> DeserializeXml()
		{
			List<Firearm> firearms = null;
			string fileContents = File.ReadAllText(GetXmlFile());

			XmlSerializer serial = new XmlSerializer(typeof(List<Firearm>), new XmlRootAttribute("data"));
			StringReader reader = new StringReader(fileContents);
			object result = serial.Deserialize(reader);

			if (result != null && result is List<Firearm>)
			{
				firearms = ((List<Firearm>)result);
			}

			reader.Close();

			return firearms;
		}

		private static string GetXmlFile()
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			string path = Uri.UnescapeDataString(new UriBuilder(codeBase).Path);
			string x = Path.GetDirectoryName(path);

			return Path.Combine(x, @"Context\Initialization\Data.xml");
		}
	}
}