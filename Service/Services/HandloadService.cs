using System.Collections.Generic;
using System.Linq;
using Reload.Common.Interfaces.Repositories;
using Reload.Common.Interfaces.Services;
using Reload.Common.Models;

namespace Reload.Service.Services
{
	/// <summary>The handload service</summary>
	public sealed class HandloadService : BaseService, IHandloadService
	{
		/// <summary>The repository</summary>
		private readonly IHandloadRepository Repository;

		/// <summary>Initializes a new instance of the <see cref="HandloadService"/> class.</summary>
		/// <param name="repository">The repository.</param>
		public HandloadService(IHandloadRepository repository)
		{
			this.Repository = repository;
		}

		/// <summary>Gets the handload.</summary>
		/// <param name="handloadId">The handload id.</param>
		public Handload Get(int handloadId)
		{
			return this.Repository.Get(x => x.HandloadId == handloadId);
		}

		/// <summary>Gets all handloads.</summary>
		public List<Handload> GetList()
		{
			return this.Repository.GetList().ToList();
		}

		/// <summary>Gets the handloads for the firearm.</summary>
		/// <param name="firearmId">The firearm id.</param>
		public List<Handload> GetList(int firearmId)
		{
			return this.Repository.GetList(h => h.FirearmId == firearmId).ToList();
		}

		/// <summary>Saves the handload.</summary>
		/// <param name="handload">The handload.</param>
		public void Save(Handload handload)
		{
			this.Repository.Save(handload, handload.HandloadId);
		}

		/// <summary>Deletes the handload by id.</summary>
		/// <param name="handloadId">The handload id.</param>
		public void Delete(int handloadId)
		{
			this.Repository.Delete(handloadId);
		}
	}
}