using System.Data.Entity;
using Reload.New.Example;
using Reload.Repository.Contexts;

namespace Reload.Web.Initialization
{
	/// <summary>The fun repository setup.</summary>
	public class FunRepoSetup : DropCreateDatabaseAlways<FunContext>
	{
		/// <summary>Seeds the specified context.</summary>
		/// <param name="context">The context.</param>
		protected override void Seed(FunContext context)
		{
			context.FunModels.Add(new FunModel
			{
				Id = 1,
				Name = "lawl"
			});

			context.SaveChanges();
		}
	}
}