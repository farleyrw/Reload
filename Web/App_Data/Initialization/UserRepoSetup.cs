﻿using System.Data.Entity;
using Reload.Common.Authentication;
using Reload.Repository.Contexts;

namespace Reload.Web.Initialization
{
	/// <summary>The User repository setup.</summary>
	public class UserRepoSetup : DropCreateDatabaseAlways<UserContext>
	{
		/// <summary>Seeds the specified context.</summary>
		/// <param name="context">The context.</param>
		protected override void Seed(UserContext context)
		{
			context.Users.Add(new UserLogin
			{
				Email = "farleyrw@gmail.com",
				FirstName = "Rich",
				LastName = "Farley",
				Password = "123456"
			});

			context.Users.Add(new UserLogin
			{
				Email = "test@example.com",
				FirstName = "Test",
				LastName = "Guy",
				Password = "123456"
			});

			context.SaveChanges();
		}
	}
}