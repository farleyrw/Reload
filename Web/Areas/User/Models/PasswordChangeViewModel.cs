using System.ComponentModel.DataAnnotations;

namespace Reload.Web.Areas.User.Models
{
	/// <summary>The password change view model.</summary>
	public class PasswordChangeViewModel
	{
		/// <summary>Gets or sets the old password.</summary>
		/// <value>The old password.</value>
		[Required]
		public string OldPassword { get; set; }

		/// <summary>Gets or sets the new password.</summary>
		/// <value>The new password.</value>
		[Required]
		public string NewPassword { get; set; }

		/// <summary>Gets or sets the confirm password.</summary>
		/// <value>The confirm password.</value>
		[Required]
		[Compare("NewPassword")]
		public string ConfirmPassword { get; set; }
	}
}