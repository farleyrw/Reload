using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using ReloadingApp.Configuration;
using ReloadingApp.Controllers;

namespace ReloadingApp.Tests.Routing
{
	[TestClass]
	public class RoutingFixture
	{
		[ClassInitialize]
		public static void Setup(TestContext testContext)
		{
			RouteTable.Routes.Clear();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		[TestMethod]
		public void DefaultRoutingTest()
		{
			"~/".ShouldMapTo<HomeController>(action => action.Index());
			"~/home".ShouldMapTo<HomeController>(action => action.Index());
			"~/home/index".ShouldMapTo<HomeController>(action => action.Index());
		}
	}
}