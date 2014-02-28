using Reload.Common.Authentication.Mvc;

namespace Reload.Common.Authentication
{
	/// <summary>The user metadata object.</summary>
	public class UserMetadata : IUserIdentityData
	{
		public UserMetadata()
		{
			IUserIdentityData user = MvcAuthentication.GetUserIdentity();

			if(user != null)
			{
				this.AccountId = user.AccountId;
				this.Email = user.Email;
				this.FirstName = user.FirstName;
				this.LastName = user.LastName;
			}
		}

		/// <summary>Gets or sets the account id.</summary>
		/// <value>The account id.</value>
		public int AccountId { get; set; }

		/// <summary>Gets or sets the email.</summary>
		/// <value>The email.</value>
		public string Email { get; set; }

		/// <summary>Gets or sets the first name.</summary>
		/// <value>The first name.</value>
		public string FirstName { get; set; }

		/// <summary>Gets or sets the last name.</summary>
		/// <value>The last name.</value>
		public string LastName { get; set; }
	}
}