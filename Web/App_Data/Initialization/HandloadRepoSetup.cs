﻿using System.Collections.Generic;
using System.Data.Entity;
using Reload.Common.Enums;
using Reload.Common.Models;
using Reload.Repository.Contexts;
using Reload.Web.Helpers.Json;

namespace Reload.Web.Initialization
{
	/// <summary>Initializes the handload repository.</summary>
	public class HandloadRepoSetup : DropCreateDatabaseAlways<HandloadContext>
	{
		/// <summary>Seeds the specified context.</summary>
		/// <param name="context">The context.</param>
		protected override void Seed(HandloadContext context)
		{
			List<Firearm> firearms = JsonDeserializationHelper.GetData<Firearm>(new EnumDescriptionConverter<Cartridge>());

			foreach(Firearm firearm in firearms)
			{
				context.Handloads.AddRange(firearm.Handloads);
			}

			context.SaveChanges();
			//base.Seed(context);
		}
	}
}