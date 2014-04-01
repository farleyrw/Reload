using System.Web.Mvc;
using Reload.Web.Controllers;

namespace Reload.Web.Areas.Handloads.Controllers
{
    public class ViewController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}