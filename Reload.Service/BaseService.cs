using Reload.Common.Authentication;

namespace Reload.Service
{
	public abstract class BaseService : IHasIdentity
	{
		public UserIdentityData Identity { get; set; }
	}
}