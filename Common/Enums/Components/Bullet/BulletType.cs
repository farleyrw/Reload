using System.ComponentModel;

namespace Reload.Common.Enums.Components.Bullet
{
	[DefaultValue(BulletType.Other)]
	public enum BulletType
	{
		Other = 0,

		[Description("Hollow Point")]
		HollowPoint,

		[Description("Round Nose")]
		RoundNose,

		[Description("FMJ")]
		FullMetalJacket,

		[Description("Ballistic Tip")]
		BallisticTip
	}
}