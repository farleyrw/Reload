
namespace Reload.Common.Authentication
{
	public interface IUserIdentityData
	{
		/// <summary>Gets or sets the account id.</summary>
		/// <value>The account id.</value>
		int AccountId { get; set; }

		/// <summary>Gets or sets the email.</summary>
		/// <value>The email.</value>
		string Email { get; set; }
	}
}