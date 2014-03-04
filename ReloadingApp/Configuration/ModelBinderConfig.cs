using System.Web.Mvc;
using ReloadingApp.Binders;

namespace ReloadingApp.Configuration
{
	/// <summary>The model binder configuration.</summary>
	public static class ModelBinderConfig
	{
		/// <summary>Registers the custom model binders.</summary>
		/// <param name="modelBinders">The model binders.</param>
		public static void RegisterModelBinders(ModelBinderDictionary modelBinders)
		{
			modelBinders.DefaultBinder = new EmptyStringModelBinder();
		}
	}
}