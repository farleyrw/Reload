using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Reload.Common.Enums;
using Reload.Common.Enums.Firearms;

namespace Reload.Common.Models
{
	/// <summary>The Firearm class.</summary>
	public class Firearm
	{
		[Key]
		public int FirearmId { get; set; }

		[Required]
		public string Model { get; set; }

		public GunManufacturer Brand { get; set; }

		public GunType Type { get; set; }

		public Cartridge Chamber { get; set; }

		[Required]
		public double BarrelLength { get; set; }

		//[ForeignKey("HandloadId")]
		public List<Handload> Handloads { get; set; }

		public Firearm()
		{
			this.Brand = GunManufacturer.Custom;
			this.Type = GunType.Other;
			this.Chamber = Cartridge.Custom;
			this.Handloads = new List<Handload>();
		}
	}
}