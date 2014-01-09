﻿using System.Linq;
using Reload.Common.Authentication;
using Reload.Repository.Context;
using Reload.Repository.Context.Initialization;
using Reload.Repository.Interfaces;

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
		public UserLogin GetUserLogin(string email, string password)
		{
			//var x = FirearmDeserialization.DeserializeXml();

			UserLogin userLogin = this.Entities
				.FirstOrDefault(user =>
					user.Email == email && 
					user.Password == password);

			return userLogin;
		}

		/// <summary>Creates a user.</summary>
		/// <param name="user">The user.</param>
		public UserLogin CreateUser(UserLogin user)
		{
			base.Save(user);

			return user;
		}
	}
}