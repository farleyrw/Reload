﻿using System.ComponentModel.DataAnnotations;
using Reload.Common.Enums;
using Reload.Common.Enums.Components.Bullet;

namespace Reload.Common.Models.Components
{
	//[ComplexType]
	public class Bullet
	{
		[Required]
		public int Weight { get; set; }

		public BulletManufacturer Brand { get; set; }

		public BulletConstruction Construction { get; set; }

		public BulletType Type { get; set; }

		public BulletBaseType BaseType { get; set; }

		public Caliber Caliber { get; set; }
	}
}