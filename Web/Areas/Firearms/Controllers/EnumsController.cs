using System.Web.Mvc;
using Reload.Common.Enums;
using Reload.Web.Controllers;
using Reload.Web.Helpers;

namespace Reload.Web.Areas.Firearms.Controllers
{
	/// <summary>The firearm enums controller.</summary>
	public class EnumsController : BaseController
	{
		/// <summary>The default view.</summary>
		public ActionResult Index()
		{
			var x = new
			{
				Cartidges = EnumViewModelHelper.ToViewModel<Cartridge>(),
				Types = EnumViewModelHelper.ToViewModel<FirearmType>()
			};

			return BaseController.GetJsonResult(x);
		}
	}
}