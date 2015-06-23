﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Reload.New.Base
{
	public interface IRepository : IDisposable
	{
		Task<TEntity> FindAsync<TEntity>(params object[] ids) where TEntity : class;

		Task<TEntity> FindWithChildrenAsync<TEntity>(
			Expression<Func<TEntity, bool>> predicate,
			IEnumerable<Expression<Func<TEntity, object>>> includes = null)
			where TEntity : class;

		void ApplyChanges<TEntity>(TEntity entity) where TEntity : class;

		Task<int> SaveChangesAsync();
	}
}