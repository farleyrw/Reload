using Reload.Common.Enums;
using Reload.Common.Enums.Components;
using Reload.Common.Enums.Components.Bullet;
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
				BulletConstuctions = EnumViewModelHelper.ToViewModel<BulletConstruction>(),
				BulletTypes = EnumViewModelHelper.ToViewModel<BulletType>(),
				BulletBaseTypes = EnumViewModelHelper.ToViewModel<BulletBaseType>(),
				Cartidges = EnumViewModelHelper.ToViewModel<Cartridge>(),
				PrimerTypes = EnumViewModelHelper.ToViewModel<PrimerType>(),
				PrimerManufacturers = EnumViewModelHelper.ToViewModel<PrimerManufacturer>(),
				Powders = EnumViewModelHelper.ToViewModel<GunPowder>(),
				FirearmTypes = EnumViewModelHelper.ToViewModel<FirearmType>()
			};
		}
	}
}