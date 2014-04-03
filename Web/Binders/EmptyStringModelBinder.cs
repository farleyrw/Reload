using System.Web.Mvc;

namespace Reload.Web.Binders
{
	/// <summary>The empty string model binder.</summary>
	public class EmptyStringModelBinder : DefaultModelBinder
	{
		/// <summary>Binds the model by using the specified controller context and binding context.</summary>
		/// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
		/// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
		/// <returns>The bound object.</returns>
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			bindingContext.ModelMetadata.ConvertEmptyStringToNull = false;

			return base.BindModel(controllerContext, bindingContext);
		}
	}
}