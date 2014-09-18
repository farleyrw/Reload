using System.ComponentModel;

namespace Reload.Common.Enums.Components.Bullet
{
	[DefaultValue(BulletConstruction.Other)]
	public enum BulletConstruction
	{
		Other = 0,

		Lead,

		[Description("Lead Free")]
		LeadFree,

		[Description("Copper Jacket")]
		CopperJacket,

		[Description("Nickel Plated")]
		NickelPlated
	}
}