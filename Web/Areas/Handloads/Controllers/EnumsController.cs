using Reload.Common.Enums;
using Reload.Web.Controllers;
using Reload.Web.Helpers;

namespace Reload.Web.Areas.Handloads.Controllers
{
	/// <summary>The handload enums controller.</summary>
	public class EnumsController : BaseEnumController
	{
		/// <summary>Gets the enum view models.</summary>
		public override dynamic GetEnumViewModels()
		{
			return new
			{
				Cartidges = EnumViewModelHelper.ToViewModel<Cartridge>()
			};
		}
	}
}