using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcRouteTester;
using Reload.Web.Configuration;
using Reload.Web.Controllers;

namespace Reload.Web.Tests.Routing
{
	[TestClass]
	public class RoutingFixture
	{
		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			RouteTable.Routes.Clear();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		[TestMethod]
		public void DefaultRoutingTest()
		{
			// https://github.com/AnthonySteele/MvcRouteTester
			//System.Web.Routing.RouteTable.Routes.ShouldMap("~/").To<HomeController>(action => action.Index());
			//System.Web.Routing.RouteTable.Routes.ShouldMap("~/Home").To<HomeController>(action => action.Index());
			//System.Web.Routing.RouteTable.Routes.ShouldMap("~/Home/Index").To<HomeController>(action => action.Index());
		}
	}
}