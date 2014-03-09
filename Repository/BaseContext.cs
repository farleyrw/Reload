using System.Data.Entity;

namespace Reload.Repository
{
	/// <summary>The base db context.</summary>
	public class BaseContext : DbContext
	{
		/// <summary>Initializes a new instance of the <see cref="BaseContext"/> class.</summary>
		public BaseContext() : base("Reload")
		{
			this.Configuration.LazyLoadingEnabled = false;
		}
	}
}