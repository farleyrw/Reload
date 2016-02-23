using Reload.Common.Attributes;
using System.ComponentModel;

namespace Reload.Common.Enums
{
	[EnumDeserializeDescription]
	[DefaultValue(Caliber.None)]
	public enum Caliber
	{
		None = -1,

		Other = 0,

		[Description("17 (.179\")")]
		Seventeen,

		[Description("20 (.204\")")]
		Twenty,

		[Description("22 (.223\")")]
		TwentyTwo,

		[Description("6mm (.243\")")]
		SixMM,

		[Description("25 (.251\")")]
		TwentyFive,

		[Description("7mm (.284\")")]
		SevenMM,

		[Description("7.62mm (.308\")")]
		SevenSixTwo,

		[Description("8mm (.323\")")]
		EightMM,

		[Description("9mm (.355\")")]
		NineMM,

		[Description("10mm (.380\")")]
		TenMM
	}
}