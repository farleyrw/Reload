using System.Data.Entity;

namespace Reload.Repository
{
	public class BaseContext : DbContext
	{
		public BaseContext() : base("Reload") { }
	}
}