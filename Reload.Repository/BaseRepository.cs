using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Reload.Common.Authentication;

namespace Reload.Repository
{
	/// <summary>The base repository for generic CRUD operations.</summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	public class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
	{
		public UserIdentityData Identity { get; set; }

		/// <summary>Gets or sets the include expressions.</summary>
		/// <value>The include expressions.</value>
		protected List<Expression<Func<TEntity, object>>> IncludeExpressions { get; set; }

		/// <summary>Gets or sets the context.</summary>
		/// <value>The context.</value>
		protected DbContext Context { get; set; }

		/// <summary>Gets the entities.</summary>
		/// <value>The entities.</value>
		protected IDbSet<TEntity> Entities { get { return this.Context.Set<TEntity>(); } }

		/// <summary>Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.</summary>
		/// <param name="context">The context.</param>
		public BaseRepository(DbContext context)
		{
			this.Context = context;
			this.IncludeExpressions = new List<Expression<Func<TEntity, object>>>();
		}

		/// <summary>Gets the entity with the specified id.</summary>
		/// <param name="id">The id.</param>
		public virtual TEntity Find(int id)
		{
			return this.Entities.Find(id);
		}

		/// <summary>Returns the element with included associations.</summary>
		/// <param name="predicate">The predicate.</param>
		public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
		{
			if(!this.IncludeExpressions.Any()) { return this.Entities.FirstOrDefault(predicate); }

			return this.IncludeExpressions
				.Aggregate(this.Entities.AsQueryable(), (current, include) => current.Include(include))
				.SingleOrDefault(predicate);
		}

		/// <summary>Gets the list.</summary>
		/// <param name="predicate">The predicate.</param>
		public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate = null)
		{
			return this.Entities.Where(predicate ?? (x => true)).AsEnumerable();
		}

		/// <summary>Saves the entity.</summary>
		/// <param name="entity">The entity.</param>
		/// <param name="primaryKey">The primary key.</param>
		public virtual void Save(TEntity entity, int primaryKey = 0)
		{
			CheckForNullEntityAndThrowExecption(entity);

			if(primaryKey == 0)
			{
				this.Insert(entity);
			}
			else
			{
				this.Update(entity);
			}

			this.Context.SaveChanges();
		}

		/// <summary>Inserts the specified entity.</summary>
		/// <param name="entity">The entity.</param>
		private void Insert(TEntity entity)
		{
			this.Entities.Add(entity);
		}

		/// <summary>Updates the specified entity.</summary>
		/// <param name="entity">The entity.</param>
		private void Update(TEntity entity)
		{
			this.Context.Entry(entity).State = EntityState.Modified;
		}

		/// <summary>Deletes the entity by id.</summary>
		/// <param name="id">The entity id.</param>
		public virtual void Delete(int id)
		{
			TEntity entityToDelete = this.Entities.Find(id);

			this.Delete(entityToDelete);
		}

		/// <summary>Deletes the specified entity.</summary>
		/// <param name="entity">The entity.</param>
		public virtual void Delete(TEntity entity)
		{
			CheckForNullEntityAndThrowExecption(entity);

			this.Entities.Remove(entity);

			this.Context.SaveChanges();
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		public void Dispose()
		{
			this.Dispose(true);

			GC.SuppressFinalize(this);
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if(disposing && this.Context != null)
			{
				this.Context.Dispose();
				this.Context = null;
			}
		}

		/// <summary>Checks for a null entity and throws an ArgumentNullException.</summary>
		/// <param name="entity">The entity.</param>
		/// <exception cref="System.ArgumentNullException">entity</exception>
		private static void CheckForNullEntityAndThrowExecption(TEntity entity)
		{
			if(entity == null)
			{
				throw new ArgumentNullException("entity");
			}
		}
	}
}