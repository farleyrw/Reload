﻿using System.Web.Routing;
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
			RouteTable.Routes.ShouldMap("~/").To<HomeController>(action => action.Index());
			RouteTable.Routes.ShouldMap("~/Home").To<HomeController>(action => action.Index());
			RouteTable.Routes.ShouldMap("~/Home/Index").To<HomeController>(action => action.Index());
		}
	}
}