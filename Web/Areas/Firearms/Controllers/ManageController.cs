using System.Web.Mvc;
using Reload.Common.Models;
using Reload.Service.Interfaces;
using Reload.Web.Controllers;

namespace Reload.Web.Areas.Firearms.Controllers
{
	/// <summary>The firearm manage controller.</summary>
	public class ManageController : BaseController
	{
		/// <summary>The firearm service.</summary>
		private readonly IFirearmService FirearmService;

		/// <summary>The firearm controller constructor.</summary>
		/// <param name="service">The service.</param>
		public ManageController(IFirearmService service)
		{
			this.FirearmService = service;
		}

		/// <summary>Returns the index view result.</summary>
		public ViewResult Index()
		{
			return View();
		}

		/// <summary>Gets the firearm list.</summary>
		public JsonResult List()
		{
			return GetJsonResult(this.FirearmService.GetList());
		}

		/// <summary>Edits the specified firearm id.</summary>
		/// <param name="id">The firearm id.</param>
		public JsonResult Edit(int id)
		{
			return GetJsonResult(this.FirearmService.Get(id));
		}

		/// <summary>Saves the specified firearm.</summary>
		/// <param name="firearm">The firearm.</param>
		[HttpPost]
		public JsonResult Save(Firearm firearm)
		{
			this.FirearmService.Save(firearm);

			return GetJsonStatusResult(true);
		}

		/// <summary>Deletes the specified firearm id.</summary>
		/// <param name="firearmId">The firearm id.</param>
		[HttpPost]
		public JsonResult Delete(int firearmId)
		{
			this.FirearmService.Delete(firearmId);

			return GetJsonStatusResult(true);
		}
	}
}