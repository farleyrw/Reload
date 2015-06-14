using Reload.Common.Interfaces.Repositories;
using Reload.Common.System;
using Reload.Repository.Context;

namespace Reload.Repository.Repositories
{
	/// <summary>The error logging repository.</summary>
	public class ErrorLoggingRepository : BaseRepository<Error>, IErrorLoggingRepository
	{
		/// <summary>Creates a new instance of the error logging repository.</summary>
		public ErrorLoggingRepository(ErrorContext context) : base(context) { }
	}
}