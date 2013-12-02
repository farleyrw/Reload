using System.Web.Mvc;
using Reload.Service.Interfaces;
using Reload.Service.Services;
using ReloadingApp.Controllers;

namespace ReloadingApp.Areas.Handloads.Controllers
{
	public class DataController : BaseController
	{
		private readonly IHandloadService Service;

		public DataController() : this(new HandloadService()) { }

		public DataController(IHandloadService service)
		{
			this.Service = service;
		}

		public ViewResult Index()
		{
			return View();
		}
	}
}