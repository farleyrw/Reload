using System.Data.Entity;
using Reload.Common.System;

namespace Reload.Repository.Contexts
{
	/// <summary>The error context.</summary>
	public class ErrorContext : BaseContext
	{
		/// <summary>Gets or sets the errors.</summary>
		/// <value>The errors.</value>
		public DbSet<Error> Errors { get; set; }
	}
}