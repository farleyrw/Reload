using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.Serialization;
using Reload.Common.Models;

namespace Reload.Repository.Context.Initialization
{
	public static class FirearmDeserialization
	{
		public static Firearm DeserializeXml()
		{
			Firearm firearms = null;
			var x = XDocument.Load(GetXmlFile());
			foreach(var element in x.Root.Elements())
			{
				element.ToString();
			}
			
			return firearms;
		}

		public static Firearm DeserializeXml_Better()
		{
			Firearm firearms = null;
			string fileContents = File.ReadAllText(GetXmlFile());
			
			XmlSerializer serial = new XmlSerializer(typeof(Firearm), new XmlRootAttribute("firearms"));
			StringReader reader = new StringReader(fileContents);
			object result = serial.Deserialize(reader);

			if (result != null && result is Firearm)
			{
				firearms = ((Firearm)result);
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