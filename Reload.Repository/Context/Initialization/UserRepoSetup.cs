using System.Data;
using System.Data.Entity;
using Reload.Common.Authentication;

namespace Reload.Repository.Context.Initialization
{
	/// <summary>The user repository setup.</summary>
	public class UserRepoSetup : DropCreateDatabaseAlways<UserContext>
	{
		/// <summary>Seeds the specified context.</summary>
		/// <param name="context">The context.</param>
		protected override void Seed(UserContext context)
		{
			UserLogin userLogin = new UserLogin
			{
				AccountId = 1,
				Email = "farleyrw@gmail.com",
				FirstName = "Rich",
				LastName = "Farley",
				Password = "123456"
			};

			if(context.Entry<UserLogin>(userLogin).State == EntityState.Detached)
			{
				context.Users.Add(userLogin);
			}

			context.SaveChanges();
		}
	}
}