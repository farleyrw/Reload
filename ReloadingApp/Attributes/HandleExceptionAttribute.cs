using System.Net;
using System.Web.Mvc;
using Reload.Common.System;
using ReloadingApp.Models;

namespace Informz.Web.App.Attributes
{
	/// <summary>The handle exception attribute.</summary>
	public class HandleExceptionAttribute : HandleErrorAttribute
	{
		/// <summary>Called when an exception occurs.</summary>
		/// <param name="filterContext">The action-filter context.</param>
		public override void OnException(ExceptionContext filterContext)
		{
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

			if(filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Exception != null)
			{
				JsonResult jsonResponse = new JsonResult
				{
					Data = new JsonStatusResult
					{
						Success = false,
						Message = error.ToString()
					},
					JsonRequestBehavior = JsonRequestBehavior.AllowGet
				};

				filterContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
				filterContext.Result = jsonResponse;
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