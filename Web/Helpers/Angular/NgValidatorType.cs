using System.ComponentModel;

namespace Reload.Web.Helpers.Angular
{
	// See: https://docs.angularjs.org/api/ng/type/form.FormController
	// See: https://msdn.microsoft.com/en-us/library/system.web.mvc.modelclientvalidationrule(v=vs.111).aspx
	[DefaultValue(Unknown)]
	public enum NgValidatorType
	{
		Unknown,

		Required,

		Minlength,

		Maxlength,

		Min,

		Max,

		[NgHtmlInputType]
		Email,

		[NgHtmlInputType]
		Number,

		Pattern,

		[NgHtmlInputType]
		Date,

		Url //?
	}
}