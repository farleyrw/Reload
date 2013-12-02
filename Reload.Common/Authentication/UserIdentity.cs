using System.Security.Principal;
using System.Web.Security;

namespace Reload.Common.Authentication
{
	/// <summary>The user identity.</summary>
	public class UserIdentity : UserIdentityData, IIdentity
	{
		/// <summary>The authentication ticket.</summary>
		private readonly FormsAuthenticationTicket Ticket;

		/// <summary>Initializes a new instance of the <see cref="UserIdentity"/> class.</summary>
		/// <param name="ticket">The ticket.</param>
		public UserIdentity(FormsAuthenticationTicket ticket) : base((ticket == null) ? string.Empty : ticket.UserData)
		{
			this.Ticket = ticket;
		}

		/// <summary>The authorization ticket name.</summary>
		/// <value>The name of the ticket.</value>
		public static string TicketName { get { return "Reloading"; } }

		/// <summary>Gets the type of authentication used.</summary>
		/// <returns>The type of authentication used to identify the user.</returns>
		public string AuthenticationType { get { return TicketName; } }

		/// <summary>Gets a value that indicates whether the user has been authenticated.</summary>
		/// <returns>true if the user was authenticated; otherwise, false.</returns>
		public bool IsAuthenticated { get { return true; } }

		/// <summary>Gets the name of the current user.</summary>
		/// <returns>The name of the user on whose behalf the code is running.</returns>
		public string Name { get { return this.Ticket.Name; } }
	}
}