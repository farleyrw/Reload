using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reload.Web.Models.Account
{
	/// <summary>The logon model.</summary>
	public class User
	{
		/// <summary>Gets or sets the email address of the user.</summary>
		/// <value>The email address of the user.</value>
		[DisplayName("Email Address")]
		[StringLength(255)]
		[DataType(DataType.EmailAddress)]
		[EmailAddress]
		[Required]
		public string Email { get; set; }

		/// <summary>Gets or sets the password.</summary>
		/// <value>The password.</value>
		[DisplayName("Password")]
		[StringLength(16, MinimumLength = 6, ErrorMessage = "The {0} does not meet the complexity requirements.")]
		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }
	}
}