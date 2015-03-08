using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using Reload.Web.Configuration;
using Reload.Web.Controllers;

namespace Reload.Web.Tests.Configuration
{
	[TestClass]
	public class RouteConfigFixture
	{
		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			RouteTable.Routes.Clear();
			RouteConfig.RegisterRoutes(RouteTable.Routes, disableTestingCrap: true);
		}

		[TestMethod]
		public void DefaultRouteTest()
		{
			RouteTable.Routes.ShouldMap("~/").To<HomeController>(action => action.Index());
			RouteTable.Routes.ShouldMap("~/Home").To<HomeController>(action => action.Index());
			RouteTable.Routes.ShouldMap("~/Home/Index").To<HomeController>(action => action.Index());
		}

		[TestMethod]
		public void StandardRouteTest()
		{
			RouteTable.Routes.ShouldMap("~/Home/Welcome").To<HomeController>(action => action.Welcome());
		}
	}
}