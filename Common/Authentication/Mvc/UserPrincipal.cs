using System.Security.Principal;

namespace Reload.Common.Authentication.Mvc
{
	/// <summary>The user principal.</summary>
	public class UserPrincipal : IPrincipal
	{
		/// <summary>Gets the identity of the current principal.</summary>
		/// <returns>The <see cref="T:System.Security.Principal.IIdentity" /> object associated with the current principal.</returns>
		public IIdentity Identity { get; private set; }

		/// <summary>Initializes a new instance of the <see cref="UserPrincipal"/> class.</summary>
		/// <param name="identity">The identity.</param>
		public UserPrincipal(IUserIdentity identity)
		{
			this.Identity = identity;
		}

		/// <summary>Determines whether the current principal belongs to the specified role.</summary>
		/// <param name="role">The name of the role for which to check membership.</param>
		/// <returns>true if the current principal is a member of the specified role; otherwise, false.</returns>
		public bool IsInRole(string role)
		{
			return true;
		}
	}
}