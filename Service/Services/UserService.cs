﻿using Reload.Common.Authentication;
using Reload.Common.Interfaces.Repositories;
using Reload.Common.Interfaces.Services;

namespace Reload.Service.Services
{
	/// <summary>The user account service.</summary>
	public sealed class UserService : BaseService, IUserService
	{
		private readonly IUserRepository Repository;

		/// <summary>Initializes a new instance of the <see cref="UserService"/> class.</summary>
		/// <param name="repository">The repository.</param>
		public UserService(IUserRepository repository)
		{
			this.Repository = repository;
		}

		/// <summary>Gets the registered user.</summary>
		/// <param name="email">The email address.</param>
		/// <param name="password">The password.</param>
		public UserLogin GetUser(string email, string password = null)
		{
			return this.Repository.GetUser(email, password);
		}

		/// <summary>Creates a registered user.</summary>
		/// <param name="user">The user.</param>
		public UserLogin CreateUser(UserLogin user)
		{
			return this.Repository.CreateUser(user);
		}

		/// <summary>Saves the specified user.</summary>
		/// <param name="user">The user.</param>
		public void Save(UserLogin user)
		{
			this.Repository.Save(user, user.AccountId);
		}

		/// <summary>Determines whether [is email available] [the specified email].</summary>
		/// <param name="email">The email.</param>
		public bool IsEmailAvailable(string email)
		{
			return this.Repository.IsEmailAvailable(email);
		}
	}
}