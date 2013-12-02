using System.Data.Entity;
using Reload.Common.Authentication;

namespace Reload.Repository.Context
{
	/// <summary>The user context.</summary>
	public class UserContext : BaseContext
	{
		/// <summary>The context's users.</summary>
		/// <value>Gets or sets the users.</value>
		public DbSet<UserLogin> Users { get; set; }
	}
}