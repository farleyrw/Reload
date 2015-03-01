using System.ComponentModel.DataAnnotations;

namespace Reload.Web.Areas.User.Models
{
	public class EmailValidationViewModel
	{
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
	}
}