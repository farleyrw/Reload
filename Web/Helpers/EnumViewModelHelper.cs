using System;
using System.Collections.Generic;
using System.Linq;
using Reload.Common.Helpers;
using Reload.Web.Models.Enums;

namespace Reload.Web.Helpers
{
	/// <summary>The enum view model helper.</summary>
	public static class EnumViewModelHelper
	{
		/// <summary>Returns the firearm enum as an kvp (Enum, Description).</summary>
		/// <typeparam name="T"></typeparam>
		public static List<EnumViewModel> ToViewModel<T>() where T : struct
		{
			return EnumHelper.Descriptions<T>()
				.Select(e => new EnumViewModel
				{
					Id = (T)e.Key as Enum,
					Name = e.Value
				})
				.ToList();
		}
	}
}