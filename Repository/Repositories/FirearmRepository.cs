using Reload.Common.Interfaces.Repositories;
using Reload.Common.Models;
using Reload.Repository.Context;

namespace Reload.Repository.Repositories
{
	/// <summary>The firearm repository.</summary>
	public class FirearmRepository : BaseRepository<Firearm>, IFirearmRepository
	{
		/// <summary>Initializes a new instance of the <see cref="FirearmRepository"/> class.</summary>
		public FirearmRepository() : this(new FirearmContext()) { }

		/// <summary>Initializes a new instance of the <see cref="FirearmRepository"/> class.</summary>
		/// <param name="context">The context.</param>
		public FirearmRepository(FirearmContext context) : base(context)
		{
			this.IncludeExpressions.Add(f => f.Handloads);
		}
	}
}