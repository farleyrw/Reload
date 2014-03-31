using System.Web.Mvc;
using Reload.Common.Authentication;

namespace ReloadingApp.Controllers
{
	/// <summary>The home controller.</summary>
    public class HomeController : BaseController
    {
		/// <summary>Returns the home view.</summary>
		[AllowAnonymous]
		public ViewResult Index()
        {
            return View();
        }

		/// <summary>Returns the about view.</summary>
		[AllowAnonymous]
		public ViewResult About()
		{
			return View();
		}

		/// <summary>Returns the welcome view.</summary>
		public ViewResult Welcome()
		{
			ViewBag.UserName = this.Identity.FirstName;
			return View();
		}
    }
}