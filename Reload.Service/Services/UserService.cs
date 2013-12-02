using Reload.Common.Authentication;
using Reload.Repository.Interfaces;
using Reload.Repository.Repositories;
using Reload.Service.Interfaces;

namespace Reload.Service.Services
{
	public class UserService : BaseService, IUserService
	{
		private readonly IUserRepository Repository;

		public UserService() : this(new UserRepository()) { }

		public UserService(IUserRepository repository)
		{
			this.Repository = repository;
		}

		/// <summary>Gets the registered user.</summary>
		/// <param name="email">The email address.</param>
		/// <param name="password">The password.</param>
		public UserLogin GetUser(string email, string password)
		{
			return this.Repository.GetUserLogin(email, password);
		}

		/// <summary>Creates a registered user.</summary>
		/// <param name="user">The user.</param>
		public UserLogin CreateUser(UserLogin user)
		{
			return this.Repository.CreateUser(user);
		}
	}
}