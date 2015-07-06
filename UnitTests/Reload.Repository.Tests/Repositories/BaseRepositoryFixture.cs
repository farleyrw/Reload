using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Models;
using Reload.New.Base;

namespace Reload.Repository.Tests.Repositories
{
	[TestClass]
	public class BaseRepositoryFixture
	{
		[TestMethod]
		public async Task CanFindEntity()
		{
			TestClass testClass = new TestClass { Id = 1 };

			ITestContext context = MockEFHelper.GetMockContext<ITestContext>()
				.CreateFakeDbSet(new List<TestClass> { testClass });

			ITestRepository repo = new TestRepository(context);

			TestClass result = await repo.FindAsync<TestClass>(1);

			Assert.IsNotNull(result);

			Assert.AreEqual(testClass.Id, result.Id);
		}

		[TestMethod]
		public async Task CantFindNonExistentEntity()
		{
			TestClass testClass = new TestClass { Id = 2 };

			ITestContext context = MockEFHelper.GetMockContext<ITestContext>()
				.CreateFakeDbSet(new List<TestClass> { testClass });

			ITestRepository repo = new TestRepository(context);

			TestClass result = await repo.FindAsync<TestClass>(1);

			Assert.IsNull(result);
		}

		[TestMethod]
		public async Task CanFindEntityWithChildren()
		{
			TestChildClass testChildClass = new TestChildClass { Id = 1 };

			TestClass testClass = new TestClass
			{
				Id = 1,
				ChildClasses = new List<TestChildClass> { testChildClass }
			};

			ITestContext context = MockEFHelper.GetMockContext<ITestContext>()
				.CreateFakeDbSet(new List<TestClass> { testClass })
				.CreateFakeDbSet(new List<TestChildClass> { testChildClass });

			// TODO: mock .Include()

			ITestRepository repo = new TestRepository(context);

			TestClass result = await repo.FindWithChildrenAsync<TestClass>(
				t => t.AccountId == 1,
				t => t.ChildClasses);

			Assert.IsNotNull(result);

			Assert.AreEqual(testClass.Id, result.Id);
		}
	}

	public interface ITestRepository : IRepository { }

	public interface ITestContext : IDbContext
	{
		DbSet<TestClass> TestClasses { get; set; }
	}

	public class TestRepository : BaseRepository<ITestContext>, ITestRepository
	{
		public TestRepository(ITestContext context) : base(context) { }
	}

	public class TestClass : IBaseModel
	{
		[Key]
		public int Id { get; set; }

		public int AccountId { get; set; }

		public List<TestChildClass> ChildClasses { get; set; }
	}

	public class TestChildClass : IBaseModel
	{
		[Key]
		public int Id { get; set; }

		public int AccountId { get; set; }
	}
}