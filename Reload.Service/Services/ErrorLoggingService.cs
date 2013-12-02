using Reload.Common.System;
using Reload.Repository.Interfaces;
using Reload.Repository.Repositories;
using Reload.Service.Interfaces;

namespace Reload.Service.Services
{
	public class ErrorLoggingService : IErrorLoggingService
	{
		private readonly IErrorLoggingRepository Repository;

		public ErrorLoggingService() : this(new ErrorLoggingRepository()) { }

		public ErrorLoggingService(IErrorLoggingRepository repository)
		{
			this.Repository = repository;
		}

		public void LogError(Error error)
		{
			this.Repository.Insert(error);
		}
	}
}