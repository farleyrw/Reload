using System.Collections.Generic;

namespace Reload.Web.Bundles.Transforms
{
	public static class BundleTransformHelper
	{
		public static string ProcessContent(string rawContent, IDictionary<string, string> settings)
		{
			foreach(KeyValuePair<string, string> setting in settings)
			{
				rawContent = rawContent.Replace(string.Format("{{{0}}}", setting.Key), setting.Value);
			}

			return rawContent;
		}
	}
}