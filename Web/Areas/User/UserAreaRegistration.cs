using System.Web.Mvc;

namespace Reload.Web.Areas.User
{
	/// <summary>The user area registration.</summary>
    public class UserAreaRegistration : AreaRegistration 
    {
		/// <summary>Gets the name of the area to register.</summary>
        public override string AreaName { get { return "User"; } }

		/// <summary>Registers an area in an ASP.NET MVC application using the specified area's context information.</summary>
		/// <param name="context">Encapsulates the information that is required in order to register the area.</param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                this.AreaName + "_default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { controller = "Manage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}