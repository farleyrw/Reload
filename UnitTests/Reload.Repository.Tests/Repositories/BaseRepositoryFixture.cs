using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Models;

namespace Reload.Repository.Tests.Repositories
{
	[TestClass]
	public class BaseRepositoryFixture
	{
		[TestMethod]
		public void EntitySavedWithAccountIdTest()
		{
			TestRepository repo = new TestRepository();

			var x = repo.Identity;

			Assert.Inconclusive();
		}
	}

	public class TestRepository : BaseRepository<TestClass>
	{
		public TestRepository() : base(new TestContext()) { }
	}

	public class TestContext : BaseContext
	{
		DbSet<TestClass> TestClasses { get; set; }
	}

	public class TestClass : IBaseModel
	{
		[Key]
		public int Id { get; set; }

		public int AccountId { get; set; }

		public string TestField { get; set; }
	}
}
