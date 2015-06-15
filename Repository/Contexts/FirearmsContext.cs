using System.Data.Entity;
using Reload.Common.Models;

namespace Reload.Repository.Contexts
{
	/// <summary>The firearm context.</summary>
	public class FirearmContext : BaseContext
	{
		/// <summary>Gets or sets the firearms.</summary>
		/// <value>The firearms.</value>
		public DbSet<Firearm> Firearms { get; set; }

		/// <summary>Gets or sets the handloads.</summary>
		/// <value>The handloads.</value>
		public DbSet<Handload> Handloads { get; set; }
	}
}