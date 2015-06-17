using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FakeItEasy;
using Reload.New.Base;

namespace Reload.Repository.Tests
{
	public static class MockEFHelper
	{
		public static TContext GetMockContext<TContext>() where TContext : IDbContext
		{
			TContext mockSet = A.Fake<TContext>();

			return mockSet;
		}

		public static TContext CreateFakeDbSet<TContext, TEntity>(
			this TContext context,
			List<TEntity> seedingList = null,
			Func<object[], TEntity, bool> isMatchFn = null)
			where TContext : IDbContext
			where TEntity : class
		{
			DbSet<TEntity> fakeDbSet = SetupDbSet(context, seedingList, isMatchFn);

			A.CallTo(() => context.Set<TEntity>()).Returns(fakeDbSet);

			A.CallTo(context).WithReturnType<DbSet<TEntity>>().Returns(fakeDbSet);

			return context;
		}

		private static DbSet<TEntity> SetupDbSet<TContext, TEntity>(
			TContext context,
			IEnumerable<TEntity> seedingList = null,
			Func<object[], TEntity, bool> isMatchingFn = null)
			where TContext : IDbContext 
			where TEntity : class
		{
			DbSet<TEntity> fakeDbSet = A.Fake<DbSet<TEntity>>(builder => 
				builder.Implements(typeof(IQueryable<TEntity>))
				.Implements(typeof(IDbAsyncEnumerable<TEntity>))
				.Strict());

			var queryableSet = (seedingList ?? new List<TEntity>()).AsQueryable();

			A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).Provider)
				.Returns(new TestDbAsyncQueryProvider<TEntity>(queryableSet.Provider));
			A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).Expression).Returns(queryableSet.Expression);
			A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).ElementType).Returns(queryableSet.ElementType);
			A.CallTo(() => ((IQueryable<TEntity>)fakeDbSet).GetEnumerator()).ReturnsLazily(() => queryableSet.GetEnumerator());

			A.CallTo(() => ((IDbAsyncEnumerable<TEntity>)fakeDbSet).GetAsyncEnumerator())
				.Returns(new TestDbAsyncEnumerator<TEntity>(queryableSet.GetEnumerator()));

			A.CallTo(() => fakeDbSet.Find(A<object[]>._))
				.ReturnsLazily((object[] ids) => FindProxy(fakeDbSet, ids, isMatchingFn));
			A.CallTo(() => fakeDbSet.FindAsync(A<object[]>._))
				.ReturnsLazily((object[] ids) => Task.FromResult<TEntity>(FindProxy(fakeDbSet, ids, isMatchingFn)));

			return fakeDbSet;
		}

		private static TEntity FindProxy<TEntity>(
			DbSet<TEntity> entities,
			object[] ids,
			Func<object[], TEntity, bool> isMatchingFn = null)
			where TEntity : class
		{
			var matcher = isMatchingFn ?? IsMatch;

			//var keys = EFTestHelpers.GetKeyNames<TEntity>(context as DbContext);

			TEntity result = entities.SingleOrDefault(x => matcher(ids, x));

			return result;
		}

		private static bool IsMatch<TEntity>(object[] ids, TEntity entity) where TEntity : class
		{
			PropertyInfo keyProperty = typeof(TEntity).GetProperties()
				.FirstOrDefault(p => p.CustomAttributes
					.Any(a => a.AttributeType == typeof(KeyAttribute)));

			return keyProperty.GetValue(entity).Equals(ids.FirstOrDefault());
		}
	}
}