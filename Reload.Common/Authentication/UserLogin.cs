using System.ComponentModel.DataAnnotations;

namespace Reload.Common.Authentication
{
	public class UserLogin
	{
		[Key]
		public int UserId { get; set; }

		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }
	}
}