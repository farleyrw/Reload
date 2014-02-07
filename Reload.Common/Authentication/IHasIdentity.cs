
namespace Reload.Common.Authentication
{
	public interface IHasIdentity
	{
		UserIdentityData Identity { get; set; }
	}
}