using System.Web.Mvc;
using ReloadingApp.Controllers;

namespace ReloadingApp.Areas.Firearms.Controllers
{
	/// <summary>The firearm view controller.</summary>
	public class ViewController : BaseController
	{
		/// <summary>Returns the index view result.</summary>
		public ViewResult Index()
		{
			return View();
		}

		/// <summary>Returns the list partial view.</summary>
		public PartialViewResult List()
		{
			return PartialView();
		}

		/// <summary>Returns the edit partial view.</summary>
		public PartialViewResult Edit()
		{
			return PartialView();
		}
	}
}