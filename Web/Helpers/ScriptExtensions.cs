using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace Reload.Web.Helpers
{
	public static class ScriptExtensions
	{
		public static IHtmlString RenderOptimized(params string[] paths)
		{
			StringBuilder content = new StringBuilder();

			foreach(string path in paths)
			{
				string scriptContent = BundleTable.Bundles.ResolveBundleUrl(path);

				content.AppendLine(string.Format(Scripts.DefaultTagFormat, scriptContent));
			}

			return MvcHtmlString.Create(content.ToString());
		}
	}
}