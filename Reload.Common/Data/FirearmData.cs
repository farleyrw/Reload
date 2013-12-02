using System.Collections.Generic;
using System.Linq;
using Reload.Common.Enums;
using Reload.Common.Enums.Firearms;
using Reload.Common.Models;

namespace Reload.Common.Data
{
	/// <summary>Firearm data</summary>
	public static class FirearmData
	{
		/// <summary>The firearms</summary>
		public static List<Firearm> Firearms { get; set; }

		/// <summary>Gets the next id.</summary>
		private static int GetNextId()
		{
			if(!Firearms.Any()) { return 1; }

			return Firearms.Max(f => f.FirearmId) + 1;
		}

		/// <summary>Gets the specified firearm id.</summary>
		/// <param name="firearmId">The firearm id.</param>
		public static Firearm Get(int firearmId)
		{
			return firearmId == 0 ? new Firearm() : Firearms.FirstOrDefault(f => f.FirearmId == firearmId);
		}

		/// <summary>Saves the specified firearm.</summary>
		/// <param name="firearm">The firearm.</param>
		public static void Save(Firearm firearm)
		{
			if(firearm.FirearmId <= 0)
			{
				firearm.FirearmId = GetNextId();
				Firearms.Add(firearm);
			}
			else
			{
				int firearmIndex = Firearms.FindIndex(f => f.FirearmId == firearm.FirearmId);
				Firearms[firearmIndex] = firearm;
			}
		}

		/// <summary>Deletes the specified firearm id.</summary>
		/// <param name="firearmId">The firearm id.</param>
		public static void Delete(int firearmId)
		{
			Firearm firearm = Firearms.FirstOrDefault(f => f.FirearmId == firearmId);

			if(firearm != null) { Firearms.Remove(firearm); }
		}

		/// <summary>Initializes this instance.</summary>
		public static void Initialize()
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
				BarrelLength = 26
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