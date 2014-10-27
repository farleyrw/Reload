using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Interfaces.Services;
using Reload.Common.Models;
using Reload.Web.Areas.Firearms.Controllers;
using Reload.Web.Models;
using Rhino.Mocks;

namespace Reload.Web.Tests
{
	[TestClass]
	public class FirearmControllerFixture
	{
		private static List<Firearm> Firearms { get; set; }
		private static IFirearmService Service { get; set; }
		private static ManageController Controller { get; set; }

		[ClassInitialize]
		public static void Initialize(TestContext context)
		{
			Firearms = new List<Firearm>();
			MockRepository mock = new MockRepository();

			Service = mock.DynamicMock<IFirearmService>();

			Service.Stub(m => m.Get(Arg<int>.Is.Anything))
				.Return(new Firearm { FirearmId = 1 });

			Service.Stub(m => m.GetList())
				.Return(Firearms);

			Service.Stub(m => m.Delete(Arg<int>.Is.Anything))
				.WhenCalled(x => Firearms.RemoveAt(1));

			Service.Stub(m => m.Save(Arg<Firearm>.Is.Anything))
				.WhenCalled(x => Firearms.Add(new Firearm()));

			mock.ReplayAll();

			Controller = new ManageController(Service);
		}

		[TestInitialize]
		public void Initialize()
		{
			Firearms.Clear();
			Firearms.AddRange(new List<Firearm> { new Firearm { FirearmId = 1 }, new Firearm { FirearmId = 2 } });
		}

		[TestMethod]
		public void GetFirearm()
		{
			Firearm firearm = (Firearm) Controller.Edit(1).Data;

			Assert.IsNotNull(firearm);
			Assert.AreEqual<int>(1, firearm.FirearmId);
		}

		[TestMethod]
		public void GetFirearms()
		{
			List<Firearm> firearms = Controller.List().Data as List<Firearm>;

			Assert.IsInstanceOfType(firearms, typeof(List<Firearm>));
			Assert.AreEqual<int>(Firearms.Count, firearms.Count);
		}

		[TestMethod]
		public void DeleteFirearm()
		{
			int startCount = Firearms.Count;

			JsonStatusResult result = (JsonStatusResult)Controller.Delete(1).Data;

			Assert.AreEqual<bool>(true, result.Success);
			Assert.AreEqual<int>(startCount - 1, Firearms.Count);
		}

		[TestMethod]
		public void SaveFirearm()
		{
			int startCount = Firearms.Count;

			JsonStatusResult result = (JsonStatusResult)Controller.Save(new Firearm()).Data;

			Assert.AreEqual<bool>(true, result.Success);
			Assert.AreEqual<int>(startCount + 1, Firearms.Count);
		}
	}
}