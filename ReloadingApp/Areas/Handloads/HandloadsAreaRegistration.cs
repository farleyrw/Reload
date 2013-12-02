using System.Web.Mvc;
using System.Web.Optimization;

namespace ReloadingApp.Areas.Handloads
{
	public class HandloadsAreaRegistration : AreaRegistration
	{
		public override string AreaName { get { return "Handloads"; } }

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				this.AreaName,
				this.AreaName + "/{controller}/{action}/{id}",
				new { action = "Index", id = UrlParameter.Optional }
			);

			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/handload")
				.IncludeDirectory("~/Areas/Handloads/Scripts", "*.js"));
		}
	}
}