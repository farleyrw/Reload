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
		[Compare("Email", ErrorMessage = "{0} does not match the email above.")]
		[Required]
		public string ConfirmEmail { get; set; }

		/// <summary>Gets or sets the confirm password.</summary>
		/// <value>The confirm password.</value>
		[DisplayName("Confirm Password")]
		[StringLength(16, MinimumLength = 6, ErrorMessage = "The {0} does not meet the complexity requirements.")]
		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "{0} does not match the password above.")]
		[Required]
		public string ConfirmPassword { get; set; }

		/// <summary>Gets or sets the first name.</summary>
		/// <value>The first name.</value>
		[DisplayName("First Name")]
		[StringLength(32)]
		[Required]
		public string FirstName { get; set; }

		/// <summary>Gets or sets the last name.</summary>
		/// <value>The last name.</value>
		[DisplayName("Last Name")]
		[StringLength(32)]
		[Required]
		public string LastName { get; set; }
	}
}