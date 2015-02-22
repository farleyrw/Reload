using System.Collections;
using System.Web.Mvc;
using Moq;

namespace Reload.Web.Tests.Helpers
{
	internal static class HtmlHelperMock
	{
		/// <summary>Gets the HTML helper.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="inputDictionary">The input dictionary.</param>
		/// <returns>A mocked HtmlHelper for unit testing.</returns>
		public static HtmlHelper<TModel> GetHtmlHelper<TModel>(TModel inputDictionary)
		{
			var viewData = new ViewDataDictionary<TModel>(inputDictionary);
			var mockViewContext = new Mock<ViewContext> { CallBase = true };
			mockViewContext.Setup(c => c.ViewData).Returns(viewData);
			mockViewContext.Setup(c => c.HttpContext.Items).Returns(new Hashtable());

			return new HtmlHelper<TModel>(mockViewContext.Object, GetViewDataContainer(viewData));
		}

		private static IViewDataContainer GetViewDataContainer(ViewDataDictionary viewData)
		{
			var mockContainer = new Mock<IViewDataContainer>();
			mockContainer.Setup(c => c.ViewData).Returns(viewData);

			return mockContainer.Object;
		}
	}
}