using System.Web.Mvc;

namespace Reload.Web.Controllers
{
	/// <summary>The base enum controller.</summary>
	public abstract class BaseEnumController : BaseController
    {
		/// <summary>Gets the enum data.</summary>
		public ActionResult Get()
		{
			return GetJsonResult(this.GetViewModel());
		}

		/// <summary>Gets the view model.</summary>
		public abstract object GetViewModel();
    }
}