using System.Data;
using System.Data.Entity;
using Reload.Common.Data;
using Reload.Common.Models;

namespace Reload.Repository.Context.Initialization
{
	/// <summary>Initializes the firearm repository.</summary>
	public class FirearmRepoSetup : DropCreateDatabaseAlways<FirearmContext>
	{
		/// <summary>Seeds the specified context.</summary>
		/// <param name="context">The context.</param>
		protected override void Seed(FirearmContext context)
		{
			FirearmData.Initialize();

			foreach(Firearm firearm in FirearmData.Firearms)
			{
				if(context.Entry<Firearm>(firearm).State == EntityState.Detached)
				{
					context.Firearms.Add(firearm);
					foreach (Handload handload in firearm.Handloads)
					{
						context.Handloads.Add(handload);
					}
				}
			}

			context.SaveChanges();
		}
	}
}