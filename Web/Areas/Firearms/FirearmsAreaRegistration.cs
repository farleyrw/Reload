using System.Web.Mvc;

namespace Reload.Web.Areas.Firearms
{
	/// <summary>The firearms area registration.</summary>
	public class FirearmsAreaRegistration : AreaRegistration
	{
		/// <summary>Gets the name of the area to register.</summary>
		/// <returns>The name of the area to register.</returns>
		public override string AreaName { get { return "Firearms"; } }

		/// <summary>Registers an area in an ASP.NET MVC application using the specified area's context information.</summary>
		/// <param name="context">Encapsulates the information that is required in order to register the area.</param>
		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				this.AreaName,
				this.AreaName + "/{controller}/{action}/{id}",
				new { controller = "Data", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}