using System.Web.Mvc;
using Reload.Common.System;
using Reload.Service.Interfaces;

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

			return this.Index();
		}

		public ViewResult NotFound()
		{
			ViewBag.Message = "Page not found.";

			return View("Error");
		}
	}
}