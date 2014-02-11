using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Reload.Common.Helpers
{
	/// <summary>The Xml serialization helper.</summary>
	public static class XmlTransformHelper
	{
		/// <summary>Serializes an object to an xml string.</summary>
		/// <param name="objectToSerialize">The object to serialize.</param>
		public static string Serialize(object objectToSerialize)
		{
			XmlSerializer xs = new XmlSerializer(objectToSerialize.GetType());

			string xml;
			using(MemoryStream ms = new MemoryStream())
			{
				xs.Serialize(ms, objectToSerialize);
				ms.Position = 0;
				using(StreamReader sr = new StreamReader(ms))
				{
					xml = sr.ReadToEnd();
				}
			}

			return xml;
		}

		/// <summary>Deserializes the specified document.</summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="document">The document.</param>
		public static T Deserialize<T>(string document) where T : class
		{
			T newObject = null;

			XDocument xd = XDocument.Parse(document);
			XmlSerializer xs = new XmlSerializer(typeof(T));
			using(XmlReader xr = xd.CreateReader())
			{
				newObject = xs.Deserialize(xr) as T;
			}

			return newObject;
		}
	}
}