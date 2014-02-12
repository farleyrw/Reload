
namespace Reload.Common.Authentication
{
	/// <summary>The user identity data interface.</summary>
	public interface IUserIdentityData
	{
		/// <summary>Gets or sets the account id.</summary>
		/// <value>The account id.</value>
		int AccountId { get; set; }

		/// <summary>Gets or sets the email.</summary>
		/// <value>The email.</value>
		string Email { get; set; }

		/// <summary>Gets or sets the first name.</summary>
		/// <value>The first name.</value>
		string FirstName { get; set; }

		/// <summary>Gets or sets the last name.</summary>
		/// <value>The last name.</value>
		string LastName { get; set; }
	}
}