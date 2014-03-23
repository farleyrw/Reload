using System.Web.Mvc;
using Reload.Common.Models;
using Reload.Service.Interfaces;
using ReloadingApp.Controllers;

namespace ReloadingApp.Areas.Firearms.Controllers
{
	/// <summary>The firearm action controller.</summary>
	public class DataController : BaseController
	{
		/// <summary>The firearm service.</summary>
		private readonly IFirearmService FirearmService;

		/// <summary>The firearm controller constructor.</summary>
		/// <param name="logic"></param>
		public DataController(IFirearmService service)
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
			return this.GetJsonResult(this.FirearmService.GetList());
		}

		/// <summary>Edits the specified firearm id.</summary>
		/// <param name="id">The firearm id.</param>
		public JsonResult Edit(int? id)
		{
			return this.GetJsonResult(this.FirearmService.Get(id.GetValueOrDefault(0)));
		}

		/// <summary>Saves the specified firearm.</summary>
		/// <param name="firearm">The firearm.</param>
		[HttpPost]
		public JsonResult Save(Firearm firearm)
		{
			this.FirearmService.Save(firearm);

			return this.GetJsonStatusResult(true, "Saved");
		}

		/// <summary>Deletes the specified firearm id.</summary>
		/// <param name="firearmId">The firearm id.</param>
		[HttpPost]
		public JsonResult Delete(int firearmId)
		{
			this.FirearmService.Delete(firearmId);

			return this.GetJsonStatusResult(true, "Deleted");
		}
	}
}