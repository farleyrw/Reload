using Reload.New.Base;

namespace Reload.New.Example
{
	public class FunRepository : BaseRepository<IFunContext>, IFunRepository
	{
		public FunRepository(IFunContext context) : base(context) { }
	}
}