using System;
using System.Linq;
using Reload.Common.Authentication;
using Reload.Common.Interfaces.Repositories;
using Reload.Repository.Context;

namespace Reload.Repository.Repositories
{
	/// <summary>The user repository.</summary>
	public class UserRepository : BaseRepository<UserLogin>, IUserRepository
	{
		/// <summary>Initializes a new instance of the <see cref="UserRepository"/> class.</summary>
		public UserRepository() : this(new UserContext()) { }

		/// <summary>Initializes a new instance of the <see cref="UserRepository"/> class.</summary>
		/// <param name="context">The context.</param>
		public UserRepository(UserContext context) : base(context) { }

		/// <summary>Returns a user login.</summary>
		/// <param name="email">The email.</param>
		/// <param name="password">The password.</param>
		public UserLogin GetUser(string email, string password)
		{
			UserLogin userLogin = this.Entities
				.FirstOrDefault(user =>
					user.Email.Equals(email, StringComparison.OrdinalIgnoreCase) && 
					user.Password == password);

			return userLogin;
		}

		/// <summary>Creates a user.</summary>
		/// <param name="user">The user.</param>
		public UserLogin CreateUser(UserLogin user)
		{
			UserLogin existingUser = this.Entities
				.FirstOrDefault(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase));

			if(existingUser == null)
			{
				this.Save(user);

				return user;
			}

			return null;
		}
	}
}