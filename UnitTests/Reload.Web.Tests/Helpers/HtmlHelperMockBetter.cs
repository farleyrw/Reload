using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace Reload.Web.Tests.Helpers
{
	internal static class HtmlHelperMockBetter
	{
		/// <summary>Gets the HTML helper.</summary>
		/// <typeparam name="TModel">The type of the model.</typeparam>
		/// <param name="inputDictionary">The input dictionary.</param>
		/// <returns>A mocked HtmlHelper for unit testing.</returns>
		public static HtmlHelper<TModel> GetHtmlHelper<TModel>(TModel inputDictionary)
		{
			var viewDataDictionary = new ViewDataDictionary<TModel>(inputDictionary);

			var mockViewContext = new Mock<ViewContext>(
				new Mock<ControllerContext>(
					new Mock<HttpContextBase>().Object,
					new Mock<RouteData>().Object,
					new Mock<ControllerBase>().Object
				).Object,
				new Mock<IView>().Object,
				viewDataDictionary,
				new TempDataDictionary(),
				new Mock<TextWriter>().Object
			) { CallBase = true };
			
			Mock<IViewDataContainer> mockDataContainer = new Mock<IViewDataContainer>();
			mockDataContainer.Setup(c => c.ViewData).Returns(viewDataDictionary);

			return new HtmlHelper<TModel>(mockViewContext.Object, mockDataContainer.Object);
		}
	}
}