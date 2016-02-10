using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Optimization;

namespace Reload.Web.Bundles.Transforms
{
	public class NameValueBundleTransform : IItemTransform
	{
		private readonly NameValueCollection Settings;

		private readonly string[] ConfigKeys;

		public NameValueBundleTransform(NameValueCollection settings, params string[] keys)
		{
			this.Settings = settings;
			this.ConfigKeys = keys;
		}

		public string Process(string includedVirtualPath, string input)
		{
			IDictionary<string, string> keyValuePairs = new Dictionary<string, string>();

			foreach(string key in this.ConfigKeys)
			{
				keyValuePairs.Add(key, this.Settings[key].ToString());
			}

			return BundleTransformHelper.ProcessContent(input, keyValuePairs);
		}
	}
}