using Reload.Common.System;
using Reload.Common.Interfaces.Repositories;
using Reload.Common.Interfaces.Services;

namespace Reload.Service.Services
{
	/// <summary>The error logging service.</summary>
	public sealed class ErrorLoggingService : IErrorLoggingService
	{
		/// <summary>The repository.</summary>
		private readonly IErrorLoggingRepository Repository;

		/// <summary>Creates a new instance of ErrorLoggingService.</summary>
		/// <param name="repository">The repository.</param>
		public ErrorLoggingService(IErrorLoggingRepository repository)
		{
			this.Repository = repository;
		}

		/// <summary>Logs the error.</summary>
		/// <param name="error">The error.</param>
		public void LogError(Error error)
		{
			this.Repository.Save(error);
		}
	}
}