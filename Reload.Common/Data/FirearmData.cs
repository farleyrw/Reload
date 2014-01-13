using System.Collections.Generic;
using System.Linq;
using Reload.Common.Enums;
using Reload.Common.Enums.Components;
using Reload.Common.Enums.Firearms;
using Reload.Common.Models;

namespace Reload.Common.Data
{
	/// <summary>Firearm data</summary>
	public static class FirearmData
	{
		/// <summary>Private static constructor.</summary>
		static FirearmData()
		{
			Initialize();
		}

		/// <summary>The firearms</summary>
		public static List<Firearm> Firearms { get; set; }

		/// <summary>Gets the next id.</summary>
		private static int GetNextId()
		{
			if(!Firearms.Any()) { return 1; }

			return Firearms.Max(f => f.FirearmId) + 1;
		}

		/// <summary>Initializes this instance.</summary>
		private static void Initialize()
		{
			if(Firearms != null) { return; }

			Firearms = new List<Firearm>();

			Firearms.Add(new Firearm
			{
				FirearmId = GetNextId(),
				Brand = GunManufacturer.Remington,
				Model = "700",
				Type = GunType.Rifle,
				Chamber = Cartridge.TwentyTwoTwoFiftyRemington,
				BarrelLength = 26,
				Handloads = new List<Handload>
				{
					new Handload
					{
						Powder = Powder.IMR4895,
						PowderCharge = 35,
						SeatingDepth = 2.5
					}
				}
			});

			Firearms.Add(new Firearm
			{
				FirearmId = GetNextId(),
				Brand = GunManufacturer.Remington,
				Model = "700",
				Type = GunType.Rifle,
				Chamber = Cartridge.TwoFourtyThreeWinchester,
				BarrelLength = 24
			});

			Firearms.Add(new Firearm
			{
				FirearmId = GetNextId(),
				Brand = GunManufacturer.Taurus,
				Model = "PT99",
				Type = GunType.Handgun,
				Chamber = Cartridge.NineLuger,
				BarrelLength = 5
			});

			Firearms.Add(new Firearm
			{
				FirearmId = GetNextId(),
				Brand = GunManufacturer.Remington,
				Model = "R1s Enhanced",
				Type = GunType.Handgun,
				Chamber = Cartridge.FourtyFiveAcp,
				BarrelLength = 5
			});

			Firearms.Add(new Firearm
			{
				FirearmId = GetNextId(),
				Brand = GunManufacturer.Savage,
				Model = "Mark II BTVS",
				Type = GunType.Rifle,
				Chamber = Cartridge.TwentyTwoLongRifle,
				BarrelLength = 20
			});
		}
	}
}