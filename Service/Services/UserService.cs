using Reload.Common.Authentication;
using Reload.Repository.Interfaces;
using Reload.Service.Interfaces;

namespace Reload.Service.Services
{
	/// <summary>The user account service.</summary>
	public class UserService : BaseService, IUserService
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
		public UserLogin GetUser(string email, string password)
		{
			return this.Repository.GetUser(email, password);
		}

		/// <summary>Creates a registered user.</summary>
		/// <param name="user">The user.</param>
		public UserLogin CreateUser(UserLogin user)
		{
			return this.Repository.CreateUser(user);
		}
	}
}