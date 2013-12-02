using System.Web.Mvc;
using ReloadingApp.Controllers;

namespace ReloadingApp.Areas.Handloads.Controllers
{
    public class ViewController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}