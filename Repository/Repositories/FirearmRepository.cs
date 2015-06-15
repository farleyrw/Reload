using Reload.Common.Interfaces.Repositories;
using Reload.Common.Models;
using Reload.Repository.Contexts;

namespace Reload.Repository.Repositories
{
	/// <summary>The firearm repository.</summary>
	public class FirearmRepository : BaseRepository<Firearm>, IFirearmRepository
	{
		/// <summary>Initializes a new instance of the <see cref="FirearmRepository"/> class.</summary>
		/// <param name="context">The context.</param>
		public FirearmRepository() : base(new FirearmContext())
		{
			this.IncludeExpressions.Add(f => f.Handloads);
		}
	}
}