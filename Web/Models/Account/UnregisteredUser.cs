using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reload.Web.Models.Account
{
	/// <summary>The unregistered user.</summary>
	public class UnregisteredUser : User
	{
		/// <summary>Gets or sets the confirm email address.</summary>
		/// <value>The confirm email address.</value>
		[DisplayName("Confirm Email")]
		[StringLength(255)]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		[Compare("Email", ErrorMessage="This does not match the email above.")]
		[Required]
		public string ConfirmEmail { get; set; }

		/// <summary>Gets or sets the confirm password.</summary>
		/// <value>The confirm password.</value>
		[DisplayName("Confirm Password")]
		[StringLength(16, MinimumLength = 6, ErrorMessage = "{0} length must be between {2} and {1} characters.")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "This does not match the password above.")]
		[Required]
		public string ConfirmPassword { get; set; }

		[DisplayName("First Name")]
		[StringLength(32)]
		[Required]
		public string FirstName { get; set; }

		[DisplayName("Last Name")]
		[StringLength(32)]
		[Required]
		public string LastName { get; set; }
	}
}