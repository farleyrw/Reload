using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reload.Common.Enums;
using Reload.Common.Enums.Firearms;
using Reload.Common.Helpers;

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

		public string ShortName
		{
			get
			{
				return string.Format(
					"{0} {1} {2}",
					EnumHelper.Description<GunManufacturer>(this.Brand),
					this.Model,
					EnumHelper.Description<Cartridge>(this.Chamber)
				);
			}
		}

		[Required]
		public double BarrelLength { get; set; }

		//[ForeignKey("HandloadId")]
		public List<Handload> Handloads { get; set; }

		public Firearm()
		{
			this.Model = string.Empty;
			this.Brand = GunManufacturer.Custom;
			this.Type = GunType.Other;
			this.Chamber = Cartridge.Custom;
			this.Handloads = new List<Handload>();
		}
	}
}