using Reload.Common.Authentication.Mvc;

namespace Reload.Common.Authentication
{
	/// <summary>Interface applying a user identity.</summary>
	public interface IHasUserIdentity
	{
		/// <summary>Gets or sets the identity.</summary>
		/// <value>The identity.</value>
		IUserIdentity Identity { get; set; }
	}
}