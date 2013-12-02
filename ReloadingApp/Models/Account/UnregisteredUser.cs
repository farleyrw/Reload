using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReloadingApp.Models.Account
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
		[Compare("Email")]
		[Required]
		public string ConfirmEmail { get; set; }

		/// <summary>Gets or sets the confirm password.</summary>
		/// <value>The confirm password.</value>
		[DisplayName("Confirm Password")]
		[StringLength(16, MinimumLength = 6, ErrorMessage = "Confirm password should be between 6 and 16 characters.")]
		[DataType(DataType.Password)]
		[Compare("Password")]
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