using System.Data.Entity;
using Reload.Repository.Context;
using ReloadingApp.Initialization;

namespace ReloadingApp.Configuration
{
	/// <summary>The database configuration.</summary>
	public static class DatabaseConfig
	{
		/// <summary>Initializes the database initializers.</summary>
		public static void RegisterInitializers()
		{
			Database.SetInitializer<FirearmContext>(new FirearmRepoSetup());
			Database.SetInitializer<UserContext>(new UserRepoSetup());
		}
	}
}