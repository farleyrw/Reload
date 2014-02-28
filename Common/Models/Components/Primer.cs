using System.ComponentModel.DataAnnotations.Schema;
using Reload.Common.Enums.Components;

namespace Reload.Common.Models.Components
{
	[ComplexType]
	public class Primer
	{
		public PrimerManufacturer PrimerBrand { get; set; }

		public PrimerType Type { get; set; }
	}
}