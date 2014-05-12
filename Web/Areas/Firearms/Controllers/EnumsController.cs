using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Reload.Common.Enums;
using Reload.Common.Helpers;
using Reload.Web.Areas.Firearms.Models;
using Reload.Web.Controllers;

namespace Reload.Web.Areas.Firearms.Controllers
{
	/// <summary>The firearm enum controller.</summary>
	public class EnumController : BaseController
	{
		/// <summary>Returns the firearm enums.</summary>
		public ActionResult Index()
		{
			return GetJsonResult(FirearmEnumHelper.GetEnums());
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
				Types = FirearmEnumHelper.ToViewModel<FirearmType>()
			};
		}

		/// <summary>Returns the firearm enum as an kvp (Enum, Description).</summary>
		/// <typeparam name="T"></typeparam>
		private static List<FirearmEnumViewModel> ToViewModel<T>() where T : struct
		{
			return EnumHelper.Descriptions<T>()
				.Select(e => new FirearmEnumViewModel
				{
					Id = (T)e.Key as Enum,
					Name = e.Value
				})
				.ToList();
		}
	}
}