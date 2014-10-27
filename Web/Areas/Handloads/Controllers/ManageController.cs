using System.Web.Mvc;
using Reload.Common.Interfaces.Services;
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

		/// <summary>Gets the handload for the specified firearm.</summary>
		/// <param name="id">The handload identifier.</param>
		public ActionResult Get(int id)
		{
			return BaseController.GetJsonResult(this.Service.Get(id));
		}

		/// <summary>Gets the handload for the specified firearm.</summary>
		public ActionResult GetThem()
		{
			return BaseController.GetJsonResult(this.Service.GetList());
		}

		/// <summary>Gets the handloads for the specified firearm.</summary>
		/// <param name="id">The firearm identifier.</param>
		public ActionResult GetAll(int id)
		{
			return BaseController.GetJsonResult(this.Service.GetList(id));
		}
	}
}