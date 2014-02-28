using System.Data.Entity;
using Reload.Common.System;

namespace Reload.Repository.Context
{
	public class ErrorContext : BaseContext
	{
		public DbSet<Error> Errors { get; set; }
	}
}