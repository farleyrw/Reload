﻿using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reload.Web.Configuration;

namespace Reload.Web.Tests.Configuration
{
	[TestClass]
	public class ViewEngineConfigFixture
	{
		private static List<IViewEngine> ViewEngines { get; set; }
		private static ViewEngineCollection ViewEngineCollection { get; set; }

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			ViewEngines = new List<IViewEngine>();
			ViewEngineCollection = new ViewEngineCollection(ViewEngines);
			ViewEngineConfig.RegisterViewEngines(ViewEngineCollection);
		}

		[TestMethod]
		[TestCategory("Application Configuration")]
		public void ShouldContainOnlyRazorViewEngine()
		{
			Assert.AreEqual(1, ViewEngines.Count);

			Assert.IsInstanceOfType(ViewEngines[0], typeof(RazorViewEngine));
		}

		[TestMethod]
		[TestCategory("Application Configuration")]
		public void ShouldRenderOnlyRazorViews()
		{
			var baseView = ViewEngines[0] as VirtualPathProviderViewEngine;

			CollectionAssert.AreEqual(new[] { "cshtml" }, baseView.FileExtensions);
		}

		[TestMethod]
		[TestCategory("Application Configuration")]
		public void ShouldHaveViewAndPartialViewsMappedTheSame()
		{
			var baseView = ViewEngines[0] as VirtualPathProviderViewEngine;

			CollectionAssert.AreEqual(baseView.ViewLocationFormats, baseView.PartialViewLocationFormats);
			CollectionAssert.AreEqual(baseView.AreaViewLocationFormats, baseView.AreaPartialViewLocationFormats);
		}
	}
}