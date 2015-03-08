using System.Net;
using System.Web.Mvc;
using Reload.Common.Interfaces.Services;
using Reload.Common.System;
using Reload.Web.Controllers;

namespace Reload.Web.Attributes
{
	/// <summary>The handle exception attribute.</summary>
	public class HandleExceptionAttribute : HandleErrorAttribute
	{
		/// <summary>The service.</summary>
		private readonly IErrorLoggingService Service;

		/// <summary>Creates a new instance of the HandleExceptionAttribute.</summary>
		/// <param name="service">The service.</param>
		public HandleExceptionAttribute(IErrorLoggingService service)
		{
			this.Service = service;
		}

		/// <summary>Called when an exception occurs.</summary>
		/// <param name="filterContext">The action-filter context.</param>
		public override void OnException(ExceptionContext filterContext)
		{
			if(!filterContext.HttpContext.Request.IsAuthenticated)
			{
				base.OnException(filterContext);

				return;
			}

			string errorLocation = filterContext.Exception.TargetSite.DeclaringType != null ?
				string.Format(
					"{0}.{1}()",
					filterContext.Exception.TargetSite.DeclaringType.FullName,
					filterContext.Exception.TargetSite.Name) :
				string.Empty;

			Error error = new Error
			{
				Location = errorLocation,
				Description = filterContext.Exception.Message,
				StackTrace = filterContext.Exception.StackTrace
			};

			this.Service.LogError(error);

			if(filterContext.HttpContext.Request.IsAjaxRequest())
			{
				filterContext.Result = BaseController.GetJsonStatusResult(false, error);
				filterContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
				filterContext.ExceptionHandled = true;
			}
			else
			{
				filterContext.RouteData.DataTokens.Add("Error", error);

				base.OnException(filterContext);
			}
		}
	}
}