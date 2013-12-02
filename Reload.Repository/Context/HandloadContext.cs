using System.Data.Entity;
using Reload.Common.Models;

namespace Reload.Repository.Context
{
	/// <summary>The handload context.</summary>
	public class HandloadContext : BaseContext
	{
		/// <summary>Gets or sets the handloads.</summary>
		/// <value>The handloads.</value>
		public DbSet<Handload> Handloads { get; set; }
	}
}