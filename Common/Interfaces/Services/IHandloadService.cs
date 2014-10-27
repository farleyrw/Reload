using System.Collections.Generic;
using Reload.Common.Models;

namespace Reload.Common.Interfaces.Services
{
	/// <summary>The handload service interface.</summary>
	public interface IHandloadService
	{
		/// <summary>Gets the handload.</summary>
		/// <param name="handloadId">The handload id.</param>
		Handload Get(int handloadId);

		/// <summary>Gets all handloads.</summary>
		List<Handload> GetList();

		/// <summary>Gets the handloads for the firearm.</summary>
		/// <param name="firearmId">The firearm id.</param>
		List<Handload> GetList(int firearmId);

		/// <summary>Saves the handload.</summary>
		/// <param name="handload">The handload.</param>
		void Save(Handload handload);

		/// <summary>Deletes the handload by id.</summary>
		/// <param name="handloadId">The handload id.</param>
		void Delete(int handloadId);
	}
}