using System.Web.Mvc;
using Reload.Common.Interfaces.Services;
using Reload.Common.System;

namespace Reload.Web.Controllers.Shared
{
	public class ErrorController : BaseController
	{
		private readonly IErrorLoggingService Service;

		public ErrorController(IErrorLoggingService service)
		{
			this.Service = service;
		}

		public ViewResult Index()
		{
			return View("Error");
		}

		[HttpPost]
		public ViewResult Index(Error error)
		{
			this.Service.LogError(error);

			return View("Error");
		}

		public ViewResult NotFound()
		{
			ViewBag.Message = "Page not found.";

			return View("Error");
		}
	}
}