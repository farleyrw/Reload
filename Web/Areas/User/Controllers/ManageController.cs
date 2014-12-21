using System.Web.Mvc;
using Reload.Web.Controllers;

namespace Reload.Web.Areas.User.Controllers
{
	/// <summary>The account controller.</summary>
    public class ManageController : BaseController
    {
		/// <summary>The default view.</summary>
        public ActionResult Index()
        {
            return View();
        }
    }
}