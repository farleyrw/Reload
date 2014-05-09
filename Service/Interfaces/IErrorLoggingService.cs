using Reload.Common.System;

namespace Reload.Service.Interfaces
{
	/// <summary>Error logging service interface.</summary>
	public interface IErrorLoggingService
	{
		/// <summary>Logs the error.</summary>
		/// <param name="error">The error.</param>
		void LogError(Error error);
	}
}