using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

		public async Task<TEntity> FindWithChildrenAsync<TEntity>(
			Expression<Func<TEntity, bool>> predicate,
			IEnumerable<Expression<Func<TEntity, object>>> includes = null)
			where TEntity : class
		{
			if(includes == null || !includes.Any())
			{
				return await this.Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
			}

			return await 
				includes.Aggregate(
					this.Context.Set<TEntity>().AsQueryable(),
					(current, include) => current.Include(include)
				)
				.SingleOrDefaultAsync(predicate);
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