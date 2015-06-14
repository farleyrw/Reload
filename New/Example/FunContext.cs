using System.Data.Entity;
using Reload.New.Base;

namespace Reload.New.Example
{
	public class FunContext : BaseContext<FunContext>, IFunContext
	{
		public DbSet<FunModel> FunModels { get; set; }
	}
}