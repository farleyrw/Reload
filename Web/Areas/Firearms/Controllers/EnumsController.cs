using Reload.Common.Enums;
using Reload.Web.Controllers;
using Reload.Web.Helpers;

namespace Reload.Web.Areas.Firearms.Controllers
{
	/// <summary>The firearm enums controller.</summary>
	public class EnumsController : BaseEnumController
	{
		/// <summary>Gets the view model.</summary>
		public override object GetViewModel()
		{
			return new
			{
				Cartidges = EnumViewModelHelper.ToViewModel<Cartridge>(),
				Types = EnumViewModelHelper.ToViewModel<FirearmType>()
			};
		}
	}
}