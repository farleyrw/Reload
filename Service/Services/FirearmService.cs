using System.Collections.Generic;
using System.Linq;
using Reload.Common.Models;
using Reload.Repository.Interfaces;
using Reload.Repository.Repositories;
using Reload.Service.Interfaces;

namespace Reload.Service.Services
{
	/// <summary>The Firearm service.</summary>
	public sealed class FirearmService : BaseService, IFirearmService
	{
		/// <summary>The firearm repository.</summary>
		private readonly IFirearmRepository Repository;

		/// <summary>Initializes a new instance of the <see cref="FirearmService"/> class.</summary>
		public FirearmService() : this(new FirearmRepository()) { }

		/// <summary>Initializes a new instance of the <see cref="FirearmService"/> class.</summary>
		/// <param name="repository">The repository.</param>
		public FirearmService(IFirearmRepository repository)
		{
			this.Repository = repository;
		}

		/// <summary>Gets the firearm with the specified id.</summary>
		/// <param name="firearmId">The firearm id.</param>
		public Firearm Get(int firearmId)
		{
			if(firearmId == 0) { return new Firearm(); }

			return this.Repository.Get(x => x.FirearmId == firearmId);
		}

		/// <summary>Gets all firearms.</summary>
		public List<Firearm> GetList()
		{
			return this.Repository.GetList().ToList();
		}

		/// <summary>Saves the firearm.</summary>
		/// <param name="firearm">The firearm.</param>
		public void Save(Firearm firearm)
		{
			this.Repository.Save(firearm, firearm.FirearmId);
		}

		/// <summary>Delets the firearm by id.</summary>
		/// <param name="id">The firearm id.</param>
		public void Delete(int id)
		{
			this.Repository.Delete(id);
		}
	}
}