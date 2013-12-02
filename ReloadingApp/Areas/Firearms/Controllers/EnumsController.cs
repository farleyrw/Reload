using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Reload.Common.Enums;
using Reload.Common.Enums.Firearms;
using Reload.Common.Helpers;
using ReloadingApp.Areas.Firearms.Models;
using ReloadingApp.Controllers;

namespace ReloadingApp.Areas.Firearms.Controllers
{
	/// <summary>The firearm enum controller.</summary>
	public class EnumsController : BaseController
	{
		/// <summary>Returns the firearm enums.</summary>
		public JsonResult Index()
		{
			return this.GetJsonResult(FirearmEnumHelper.GetEnums());
		}
	}

	/// <summary>The Firearm enum helper.</summary>
	public static class FirearmEnumHelper
	{
		/// <summary>Gets the enums.</summary>
		public static dynamic GetEnums()
		{
			return new
			{
				Cartidges = FirearmEnumHelper.ToViewModel<Cartridge>(),
				Brands = FirearmEnumHelper.ToViewModel<GunManufacturer>(),
				Types = FirearmEnumHelper.ToViewModel<GunType>()
			};
		}

		/// <summary>Returns the firearm enum as an kvp (Enum, Description).</summary>
		/// <typeparam name="TEnum"></typeparam>
		private static List<FirearmEnum> ToViewModel<TEnum>() where TEnum : struct
		{
			return EnumHelper.Descriptions<TEnum>()
				.Select(e => new FirearmEnum
				{
					Id = (TEnum) e.Key as Enum,
					Name = e.Value
				})
				.ToList();
		}
	}
}