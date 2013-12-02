using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Common.Models;
using Reload.Service.Interfaces;
using ReloadingApp.Areas.Firearms.Controllers;
using Rhino.Mocks;

namespace ReloadingApp.Tests
{
	[TestClass]
	public class FirearmControllerFixture
	{
		private static List<Firearm> Firearms { get; set; }
		private static IFirearmService Service { get; set; }
		private static DataController Controller { get; set; }

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

			Controller = new DataController(Service);
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
			Firearm firearm = Controller.Edit(1).Data as Firearm;

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

			Controller.Delete(1);

			Assert.AreEqual<int>(startCount - 1, Firearms.Count);
		}

		[TestMethod]
		public void SaveFirearm()
		{
			int startCount = Firearms.Count;

			Controller.Save(new Firearm());

			Assert.AreEqual<int>(startCount + 1, Firearms.Count);
		}
	}
}