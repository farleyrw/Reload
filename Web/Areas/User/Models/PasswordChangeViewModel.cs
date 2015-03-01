using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Reload.Web.Areas.User.Models
{
	/// <summary>The password change view model.</summary>
	public class PasswordChangeViewModel
	{
		/// <summary>Gets or sets the old password.</summary>
		/// <value>The old password.</value>
		[Required]
		[DisplayName("Old Password")]
		public string OldPassword { get; set; }

		/// <summary>Gets or sets the new password.</summary>
		/// <value>The new password.</value>
		[Required]
		[StringLength(32, MinimumLength = 6)]
		[DisplayName("New Password")]
		public string NewPassword { get; set; }

		/// <summary>Gets or sets the confirm password.</summary>
		/// <value>The confirm password.</value>
		[Required]
		[Compare("NewPassword")]
		[DisplayName("Confirm Password")]
		public string ConfirmPassword { get; set; }
	}
}