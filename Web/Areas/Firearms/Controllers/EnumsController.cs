using Reload.Common.Enums;
using Reload.Web.Controllers;
using Reload.Web.Helpers;

namespace Reload.Web.Areas.Firearms.Controllers
{
	/// <summary>The firearm enums controller.</summary>
	public class EnumsController : BaseEnumController
	{
		/// <summary>Gets the enum view models.</summary>
		public override dynamic GetEnumViewModels()
		{
			return new
			{
				Cartidges = EnumViewModelHelper.ToViewModel<Cartridge>(),
				Types = EnumViewModelHelper.ToViewModel<FirearmType>()
			};
		}
	}
}