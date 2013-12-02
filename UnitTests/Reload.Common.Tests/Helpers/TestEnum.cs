using System.ComponentModel;

namespace Reload.Common.Tests.Helpers
{
	public enum TestEnum
	{
		[Description("A")]
		A = 0,
		[Description("B")]
		B,
		[Description("C")]
		C
	}
}