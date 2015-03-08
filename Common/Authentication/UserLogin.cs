using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Reload.Common.Models;

namespace Reload.Common.Authentication
{
	/// <summary>The user login model.</summary>
	public class UserLogin : IBaseModel
	{
		[Key]
		public int AccountId { get; set; }

		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		// TODO: do not store this value as plain text.
		public string Password { get; set; }

		[Required]
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Required]
		[DisplayName("Last Name")]
		public string LastName { get; set; }
	}
}