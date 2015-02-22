using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Reload.Web.Tests.Helpers
{
	//Creates an HtmlHelper for unit testing
	public class HtmlHelperFactory
	{
		/// <summary>Create a new HtmlHelper with fake dependencies.</summary>
		/// <returns>HtmlHelper</returns>
		public static HtmlHelper<T> Create<T>(T model)
		{
			ViewContext vc = new ViewContext
			{
				HttpContext = new FakeHttpContext()
			};

			return new HtmlHelper<T>(vc, new FakeViewDataContainer<T>(model));
		}

		private class FakeHttpContext : HttpContextBase
		{
			private readonly Dictionary<object, object> items = new Dictionary<object, object>();

			public override IDictionary Items { get { return items; } }
		}

		private class FakeViewDataContainer<T> : IViewDataContainer
		{
			public FakeViewDataContainer(T model)
			{
				this.ViewData = new ViewDataDictionary<T>(model);
			}

			public ViewDataDictionary ViewData { get; set; }
		}
	}
}