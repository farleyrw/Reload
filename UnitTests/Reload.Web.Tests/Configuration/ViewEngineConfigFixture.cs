using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

			CollectionAssert.AreEqual(new string[] { "cshtml" }, baseView.FileExtensions);
		}

		[TestMethod]
		[TestCategory("Application Configuration")]
		public void ShouldHaveViewAndPartialViewsMappedTheSame()
		{
			var baseView = ViewEngines[0] as VirtualPathProviderViewEngine;

			CollectionAssert.AreEqual(baseView.ViewLocationFormats, baseView.PartialViewLocationFormats);
			CollectionAssert.AreEqual(baseView.AreaViewLocationFormats, baseView.AreaPartialViewLocationFormats);
		}

		[TestMethod]
		[TestCategory("Application Configuration")]
		public void ShouldHaveMasterViewsMapped()
		{
			var baseView = ViewEngines[0] as VirtualPathProviderViewEngine;

			// TODO: these tests have no meaning.  Figure out what Master Locations are.
			CollectionAssert.AreEqual(baseView.ViewLocationFormats, baseView.MasterLocationFormats);
			CollectionAssert.AreEqual(baseView.AreaViewLocationFormats, baseView.AreaMasterLocationFormats);
		}
	}
}