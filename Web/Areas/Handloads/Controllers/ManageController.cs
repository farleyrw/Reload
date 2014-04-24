using System.Web.Mvc;
using Reload.Service.Interfaces;
using Reload.Web.Controllers;

namespace Reload.Web.Areas.Handloads.Controllers
{
	/// <summary>The handload manage controller.</summary>
	public class ManageController : BaseController
	{
		/// <summary>The handload service.</summary>
		private readonly IHandloadService Service;

		/// <summary>Initializes a new instance of the <see cref="ManageController"/> class.</summary>
		/// <param name="service">The service.</param>
		public ManageController(IHandloadService service)
		{
			this.Service = service;
		}

		/// <summary>The index view result.</summary>
		public ViewResult Index()
		{
			return View();
		}
	}
}