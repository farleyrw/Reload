using Reload.Common.Authentication;

namespace Reload.Common.Interfaces.Services
{
	/// <summary>The user service interface.</summary>
	public interface IUserService
	{
		/// <summary>Gets the registered user.</summary>
		/// <param name="email">The email address.</param>
		/// <param name="password">The password.</param>
		UserLogin GetUser(string email, string password = null);

		/// <summary>Creates a registered user.</summary>
		/// <param name="user">The user.</param>
		UserLogin CreateUser(UserLogin user);
		
		/// <summary>Saves the specified user.</summary>
		/// <param name="user">The user.</param>
		void Save(UserLogin user);

		/// <summary>Determines whether [is email available] [the specified email].</summary>
		/// <param name="email">The email.</param>
		bool IsEmailAvailable(string email);
	}
}