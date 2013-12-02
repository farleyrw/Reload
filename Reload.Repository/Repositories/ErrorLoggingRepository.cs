using Reload.Common.System;
using Reload.Repository.Context;
using Reload.Repository.Interfaces;

namespace Reload.Repository.Repositories
{
	/// <summary>The error logging repository.</summary>
	public class ErrorLoggingRepository : BaseRepository<Error>, IErrorLoggingRepository
	{
		public ErrorLoggingRepository() : this(new ErrorContext()) { }

		public ErrorLoggingRepository(ErrorContext context) : base(context) { }
	}
}