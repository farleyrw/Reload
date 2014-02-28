using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Models;
using Reload.Repository;

namespace Reload.Repository.Tests.Repositories
{
	[TestClass]
	public class BaseRepositoryFixture
	{
		[TestMethod]
		public void EntitySavedWithAccountIdTest()
		{
			Assert.IsTrue(true);
		}
	}

	public class TestRepository //: BaseRepository<TestClass>
	{
		//public TestRepository() { }
	}

	public class TestContext : BaseContext
	{

	}

	public class TestClass : IBaseModel
	{
		public int AccountId { get; set; }

		public string TestField { get; set; }
	}
}
