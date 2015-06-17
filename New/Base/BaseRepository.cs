using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Reload.New.Base
{
	public abstract class BaseRepository<TContext> : IRepository where TContext : class, IDbContext
	{
		protected TContext Context { get; set; }

		public BaseRepository(IDbContext context)
		{
			this.Context = context as TContext;
		}

		public async Task<TEntity> FindAsync<TEntity>(params object[] ids) where TEntity : class
		{
			return await this.Context.Set<TEntity>().FindAsync(ids);
		}

		public async Task<TEntity> FindWithChildrenAsync<TEntity>(params object[] ids) where TEntity : class
		{
			// TODO: create way to add include properties
			return await this.FindAsync<TEntity>(ids);
		}

		public void ApplyChanges<TEntity>(TEntity entity) where TEntity : class
		{
			throw new NotImplementedException();
		}

		public async Task<int> SaveChangesAsync()
		{
			return await this.Context.SaveChangesAsync();
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if(disposing && this.Context != null)
			{
				this.Context.Dispose();
			}
		}
	}
}