using System.ComponentModel.DataAnnotations;

namespace Reload.Web.Tests.Helpers.Angular
{
	public class NgTestModel
	{
		[Required]
		public string RequiredProperty { get; set; }

		[StringLength(10)]
		public string MaxLength10Property { get; set; }

		[StringLength(10, MinimumLength = 5)]
		public string Between5And10Property { get; set; }

		[RegularExpression("\\d")]
		public string PatternProperty { get; set; }

		[Required]
		[StringLength(5)]
		public string MultipleValidationProperty { get; set; }
	}
}