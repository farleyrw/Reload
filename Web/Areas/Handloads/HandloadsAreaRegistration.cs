﻿using System.Web.Mvc;
using System.Web.Optimization;

namespace Reload.Web.Areas.Handloads
{
	/// <summary>The handload area registration.</summary>
	public class HandloadsAreaRegistration : AreaRegistration
	{
		/// <summary>Gets the name of the area to register.</summary>
		/// <returns>The name of the area to register.</returns>
		public override string AreaName { get { return "Handloads"; } }

		/// <summary>Registers an area in an ASP.NET MVC application using the specified area's context information.</summary>
		/// <param name="context">Encapsulates the information that is required in order to register the area.</param>
		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				this.AreaName,
				this.AreaName + "/{controller}/{action}/{id}",
				new { controller = "Manage", action = "Index", id = UrlParameter.Optional }
			);
		}
	}
}