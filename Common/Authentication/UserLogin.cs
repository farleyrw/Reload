using System.ComponentModel.DataAnnotations;
using Reload.Common.Models;

namespace Reload.Common.Authentication
{
	public class UserLogin : IBaseModel
	{
		[Key]
		public int AccountId { get; set; }

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