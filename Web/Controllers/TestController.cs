using System.Threading.Tasks;
using System.Web.Mvc;
using Reload.New.Example;

namespace Reload.Web.Controllers
{
	[AllowAnonymous]
    public class TestController : BaseController
    {
		/*private readonly IFunRepository Repository;

		public TestController(IFunRepository repository)
		{
			this.Repository = repository;
		}*/

        public async Task<ActionResult> Index()
        {
			var result = await new FunRepository(new FunContext()).FindAsync<FunModel>(1);

            return BaseController.GetJsonResult(result);
        }
    }
}