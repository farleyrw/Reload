using System.Data.Entity;
using Reload.Repository.Contexts;
using Reload.Web.Initialization;

namespace Reload.Web.Configuration
{
	/// <summary>The database configuration.</summary>
	public static class DatabaseConfig
	{
		/// <summary>Initializes the database initializers.</summary>
		public static void RegisterInitializers()
		{
			Database.SetInitializer<UserContext>(new UserRepoSetup());
			Database.SetInitializer<FirearmContext>(new FirearmRepoSetup());
			Database.SetInitializer<HandloadContext>(new HandloadRepoSetup());
		}
	}
}