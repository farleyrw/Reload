using System.Collections.Generic;
using System.Linq;
using Reload.Common.Models;
using Reload.Repository.Interfaces;
using Reload.Repository.Repositories;
using Reload.Service.Interfaces;

namespace Reload.Service.Services
{
	/// <summary>The handload service</summary>
	public class HandloadService : BaseService, IHandloadService
	{
		/// <summary>The repository</summary>
		private readonly IHandloadRepository Repository;

		/// <summary>Initializes a new instance of the <see cref="HandloadService"/> class.</summary>
		public HandloadService() : this(new HandloadRepository()) { }

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
			return this.Repository.Find(handloadId);
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
			if(handload.HandloadId > 0)
			{
				this.Repository.Update(handload);
			}
			else
			{
				this.Repository.Insert(handload);
			}
		}

		/// <summary>Deletes the handload by id.</summary>
		/// <param name="handloadId">The handload id.</param>
		public void Delete(int handloadId)
		{
			this.Repository.Delete(handloadId);
		}
	}
}