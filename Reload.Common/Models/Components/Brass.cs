using System.ComponentModel.DataAnnotations.Schema;
using Reload.Common.Enums;
using Reload.Common.Enums.Components;

namespace Reload.Common.Models.Components
{
	/// <summary>The brass</summary>
	[ComplexType]
	public class Brass
	{
		/// <summary>Gets or sets the manufacturer.</summary>
		/// <value>The manufacturer.</value>
		public BrassManufacturer Manufacturer { get; set; }

		/// <summary>Gets or sets the caliber.</summary>
		/// <value>The caliber.</value>
		public Cartridge Caliber { get; set; }

		/// <summary>Gets or sets the times fired.</summary>
		/// <value>The times fired.</value>
		public int TimesFired { get; set; }
	}
}