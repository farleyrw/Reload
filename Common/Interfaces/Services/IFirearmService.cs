using System.Collections.Generic;
using Reload.Common.Models;

namespace Reload.Common.Interfaces.Services
{
	/// <summary>The firearm service interface.</summary>
	public interface IFirearmService
	{
		/// <summary>Gets the firearm.</summary>
		/// <param name="firearmId">The firearm id.</param>
		Firearm Get(int firearmId);

		/// <summary>Gets the firearms.</summary>
		List<Firearm> GetList();

		/// <summary>Saves the firearm.</summary>
		/// <param name="firearm">The firearm.</param>
		void Save(Firearm firearm);

		/// <summary>Deletes the firearm by id.</summary>
		/// <param name="id">The firearm id.</param>
		void Delete(int id);
	}
}