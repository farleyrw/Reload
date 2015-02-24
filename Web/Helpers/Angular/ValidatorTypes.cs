
namespace Reload.Web.Helpers.Angular
{
	// See: https://docs.angularjs.org/api/ng/type/form.FormController
	// See: https://msdn.microsoft.com/en-us/library/system.web.mvc.modelclientvalidationrangerule(v=vs.111).aspx
	public enum ValidatorTypes
	{
		Required,

		Minlength,

		Maxlength,

		//Range,

		Email,

		Number,
		
		Pattern,

		Date,
		
		Url
	}
}