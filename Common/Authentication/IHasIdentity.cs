
namespace Reload.Common.Authentication
{
	/// <summary>Interface applying user identity data.</summary>
	public interface IHasIdentityData
	{
		/// <summary>Gets or sets the identity.</summary>
		/// <value>The identity.</value>
		IUserIdentityData Identity { get; set; }
	}
}