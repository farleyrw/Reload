using Reload.Common.System;

namespace Reload.Service.Interfaces
{
	public interface IErrorLoggingService
	{
		void LogError(Error error);
	}
}