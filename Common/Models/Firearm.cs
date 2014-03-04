using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Reload.Common.Enums;
using Reload.Common.Helpers;

namespace Reload.Common.Models
{
	/// <summary>The Firearm class.</summary>
	public class Firearm : IBaseModel
	{
		[Key]
		public int FirearmId { get; set; }

		public int AccountId { get; set; }

		[Required]
		public string Model { get; set; }

		public string Brand { get; set; }

		public FirearmType Type { get; set; }

		public Cartridge Chamber { get; set; }

		public string Name
		{
			get
			{
				return string.Format(
					"{0} {1} {2}",
					this.Brand,
					this.Model,
					EnumHelper.Description<Cartridge>(this.Chamber)
				);
			}
		}

		[Required]
		public double BarrelLength { get; set; }

		public List<Handload> Handloads { get; set; }

		public Firearm()
		{
			this.Type = FirearmType.Other;
			this.Chamber = Cartridge.None;
			this.Handloads = new List<Handload>();
		}
	}
}