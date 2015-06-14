using System.Data.Entity;
using System.Diagnostics;

namespace Reload.Repository
{
	/// <summary>The base db context.</summary>
	public class BaseContext : DbContext
	{
		/// <summary>Initializes a new instance of the <see cref="BaseContext"/> class.</summary>
		public BaseContext()// : base("DefaultConnection")
		{
			this.Configuration.LazyLoadingEnabled = false;

			this.Database.Log = s => Debug.WriteLine(s);
		}
	}
}