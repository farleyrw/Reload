using Reload.Common.Authentication;

namespace Reload.Service
{
	public abstract class BaseService : IHasIdentityData
	{
		/// <summary>Gets or sets the identity.</summary>
		/// <value>The identity.</value>
		public IUserIdentityData Identity { get; set; }
	}
}