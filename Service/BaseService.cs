using Reload.Common.Authentication;
using Reload.Common.Authentication.Mvc;

namespace Reload.Service
{
	/// <summary>The base service class.</summary>
	public abstract class BaseService : IHasUserIdentity
	{
		/// <summary>Gets or sets the identity.</summary>
		/// <value>The identity.</value>
		public IUserIdentity Identity { get; set; }
	}
}