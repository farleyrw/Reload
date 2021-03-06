﻿using System.Collections.Generic;
using System.Data.Entity;
using Reload.Common.Enums;
using Reload.Common.Models;
using Reload.Repository.Contexts;
using Reload.Web.Helpers.Json;

namespace Reload.Web.Initialization
{
	/// <summary>Initializes the firearm repository.</summary>
	public class FirearmRepoSetup : DropCreateDatabaseAlways<FirearmContext>
	{
		/// <summary>Seeds the specified context.</summary>
		/// <param name="context">The context.</param>
		protected override void Seed(FirearmContext context)
		{
			List<Firearm> firearms = JsonDeserializationHelper.GetData<Firearm>(new EnumDescriptionConverter<Cartridge>());

			foreach(Firearm firearm in firearms)
			{
				// Remove handloads because they are going in another context for now.
				firearm.Handloads = new List<Handload>();
				context.Firearms.Add(firearm);
				//context.Handloads.AddRange(firearm.Handloads);
			}

			context.SaveChanges();
		}
	}
}