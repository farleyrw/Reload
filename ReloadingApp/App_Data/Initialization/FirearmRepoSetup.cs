using System.Collections.Generic;
using System.Data.Entity;
using Reload.Common.Models;
using Reload.Repository.Context;
using ReloadingApp.Helpers.Json;

namespace ReloadingApp.Initialization
{
	/// <summary>Initializes the firearm repository.</summary>
	public class FirearmRepoSetup : DropCreateDatabaseAlways<FirearmContext>
	{
		/// <summary>Seeds the specified context.</summary>
		/// <param name="context">The context.</param>
		protected override void Seed(FirearmContext context)
		{
			List<Firearm> firearms = JsonDeserializationHelper.GetData<Firearm>(new CartridgeEnumDescriptionConverter());

			foreach(Firearm firearm in firearms)
			{
				context.Firearms.Add(firearm);
				context.Handloads.AddRange(firearm.Handloads);
			}

			context.SaveChanges();
		}
	}
}