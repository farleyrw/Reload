using Reload.Common.Authentication;

namespace Reload.Common.Interfaces.Repositories
{
	/// <summary>The user repository interface.</summary>
	public interface IUserRepository : IRepository<UserLogin>
	{
		/// <summary>Returns a user login.</summary>
		/// <param name="email">The email.</param>
		/// <param name="password">The password.</param>
		UserLogin GetUser(string email, string password);

		/// <summary>Creates a user.</summary>
		/// <param name="user">The user.</param>
		UserLogin CreateUser(UserLogin user);
		
		/// <summary>Determines whether [is email available] [the specified email].</summary>
		/// <param name="email">The email.</param>
		bool IsEmailAvailable(string email);
	}
}