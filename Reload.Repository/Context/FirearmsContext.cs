using System.Data.Entity;
using Reload.Common.Models;

namespace Reload.Repository.Context
{
	/// <summary>The firearm context.</summary>
	public class FirearmContext : BaseContext
	{
		/// <summary>Gets or sets the firearms.</summary>
		/// <value>The firearms.</value>
		public DbSet<Firearm> Firearms { get; set; }
	}
}