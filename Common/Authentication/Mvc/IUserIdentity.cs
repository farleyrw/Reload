using System.Security.Principal;

namespace Reload.Common.Authentication.Mvc
{
	/// <summary>The user identity interface.</summary>
	public interface IUserIdentity : IIdentity
	{
		/// <summary>Gets or sets the account identifier.</summary>
		/// <value>The account identifier.</value>
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