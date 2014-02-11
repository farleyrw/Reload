using System.Data.Entity;
using Reload.Repository.Context;
using Reload.Repository.Context.Initialization;

namespace ReloadingApp.Configuration
{
	/// <summary>The database configuration.</summary>
	public static class DatabaseConfig
	{
		/// <summary>Initializes the database configuration.</summary>
		public static void Initialize()
		{
			Database.SetInitializer<FirearmContext>(new FirearmRepoSetup());
			Database.SetInitializer<UserContext>(new UserRepoSetup());
		}
	}
}