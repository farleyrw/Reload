
namespace Reload.Common.Authentication.Mvc
{
	/// <summary>The user identity.</summary>
	public class UserIdentity : IUserIdentity
	{
		/// <summary>Initializes a new instance of the <see cref="UserIdentity"/> class.</summary>
		/// <param name="ticket">The ticket.</param>
		public UserIdentity()
		{
			this.Email = string.Empty;
			this.FirstName = string.Empty;
			this.LastName = string.Empty;
		}

		/// <summary>The authorization ticket name.</summary>
		/// <value>The name of the ticket.</value>
		public static string TicketName { get { return "Reloading"; } }

		/// <summary>Gets the type of authentication used.</summary>
		/// <returns>The type of authentication used to identify the user.</returns>
		public string AuthenticationType { get { return "Forms"; } }

		/// <summary>Gets a value that indicates whether the user has been authenticated.</summary>
		/// <returns>true if the user was authenticated; otherwise, false.</returns>
		public bool IsAuthenticated { get { return true; } }

		/// <summary>Gets the name of the current user.</summary>
		/// <returns>The name of the user on whose behalf the code is running.</returns>
		public string Name { get { return this.Email; } }

		/// <summary>Gets or sets the account identifier.</summary>
		/// <value>The account identifier.</value>
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