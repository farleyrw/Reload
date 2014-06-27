using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Reload.Repository
{
	/// <summary>The repository interface.</summary>
	/// <typeparam name="TEntity">The generic entity.</typeparam>
	public interface IRepository<TEntity> where TEntity : class
	{
		/// <summary>Finds the entity with the specified id.</summary>
		/// <param name="ids">The entity ids.</param>
		TEntity Find(params object[] ids);

		/// <summary>Returns the element with it's associations.</summary>
		/// <param name="predicate">The predicate.</param>
		TEntity Get(Expression<Func<TEntity, bool>> predicate);

		/// <summary>Gets an entity list.</summary>
		/// <param name="predicate">The predicate.</param>
		IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null);

		/// <summary>Saves the entity.</summary>
		/// <param name="entity">The entity.</param>
		/// <param name="primaryKey">The primary key.</param>
		void Save(TEntity entity, int primaryKey = 0);

		/// <summary>Deletes the entity by id.</summary>
		/// <param name="id">The entity id.</param>
		void Delete(int id);

		/// <summary>Deletes the entity.</summary>
		/// <param name="entity">The entity.</param>
		void Delete(TEntity entity);
	}
}