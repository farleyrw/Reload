using System.Data.Entity;
using System.Diagnostics;

namespace Reload.New.Base
{
	public abstract class BaseContext<TContext> : DbContext, IDbContext where TContext : DbContext
	{
		static BaseContext()
		{
			//Database.SetInitializer<TContext>(null);
		}

		public BaseContext()
		{
			this.Configuration.LazyLoadingEnabled = false;

			this.Database.Log = s => Debug.WriteLine(s);
		}
	}
}