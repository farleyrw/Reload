using System.Data.Entity;
using Reload.New.Base;

namespace Reload.New.Example
{
	public interface IFunContext : IDbContext
	{
		DbSet<FunModel> FunModels { get; set; }
	}
}