using System;
using System.Threading.Tasks;

namespace Reload.New.Base
{
	public interface IRepository : IDisposable
	{
		Task<TEntity> FindAsync<TEntity>(params object[] ids) where TEntity : class;

		Task<TEntity> FindWithChildrenAsync<TEntity>(params object[] ids) where TEntity : class;

		void ApplyChanges<TEntity>(TEntity entity) where TEntity : class;

		Task<int> SaveChangesAsync();
	}
}