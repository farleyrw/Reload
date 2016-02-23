using Reload.Common.Attributes;
using System.ComponentModel;

namespace Reload.Common.Enums.Components
{
	/// <summary>The primer type.</summary>
	[EnumDeserializeDescription]
	[DefaultValue(PrimerType.Other)]
	public enum PrimerType
	{
		Other = 0,

		[Description("Small Rifle")]
		SmallRifle,

		[Description("Small Rifle Magnum")]
		SmallRifleMagnum,

		[Description("Large Rifle")]
		LargeRifle,

		[Description("Large Rifle Magnum")]
		LargeRifleMagnum,

		[Description("Small Pistol")]
		SmallPistol,

		[Description("Small Pistol Magnum")]
		SmallPistolMagnum,

		[Description("Large Pistol")]
		LargePistol,

		[Description("Large Pistol Magnum")]
		LargePistolMagnum
	}
}