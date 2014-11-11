using System.Web.Mvc;
using System.Web.Security;
using MvcContrib;
using Reload.Common.Authentication;
using Reload.Common.Authentication.Mvc;
using Reload.Common.Interfaces.Services;
using Reload.Web.Models.Account;

namespace Reload.Web.Controllers
{
	/// <summary>The account controller.</summary>
	[AllowAnonymous]
	public class AccountController : BaseController
	{
		/// <summary>The service.</summary>
		private readonly IUserService Service;

		/// <summary>Initializes a new instance of the <see cref="AccountController"/> class.</summary>
		/// <param name="service">The service.</param>
		public AccountController(IUserService service)
		{
			this.Service = service;
		}

		/// <summary>Gets the index view result, default login page.</summary>
		public RedirectToRouteResult Index()
		{
			return this.RedirectToAction(action => action.Login(false));
		}

		/// <summary>The login view.</summary>
		public ActionResult Login(bool? autoLogout = false)
		{
			if(this.Request.IsAuthenticated)
			{
				return this.RedirectToAction<HomeController>(action => action.Welcome());
			}

			FormsAuthentication.SignOut();

			ViewBag.AutoLogout = autoLogout.GetValueOrDefault(false);

			return View();
		}

		/// <summary>The register view.</summary>
		public ActionResult Register()
		{
			// TODO: remove this duplication.
			if(this.Request.IsAuthenticated)
			{
				return this.RedirectToAction<HomeController>(action => action.Welcome());
			}

			FormsAuthentication.SignOut();

			return View();
		}

		/// <summary>Authenticates the specified user.</summary>
		/// <param name="user">The user.</param>
		/// <param name="returnUrl">The return URL.</param>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Login")]
		public ActionResult Authenticate(User user, string returnUrl)
		{
			if(!ModelState.IsValid) { return View(user); }

			UserLogin userLogin = this.Service.GetUser(user.Email, user.Password);

			// If user was not found, bad credentials were given.
			if(userLogin == null)
			{
				ModelState.AddModelError("", "Invalid username or password.");
				return View(user);
			}

			IUserIdentity userData = new UserIdentity
			{
				AccountId = userLogin.AccountId,
				Email = userLogin.Email,
				FirstName = userLogin.FirstName,
				LastName = userLogin.LastName
			};

			MvcAuthentication.AuthenticateUser(userData);

			if(Url.IsLocalUrl(returnUrl))
			{
				return this.Redirect(returnUrl);
			}

			return this.RedirectToAction<HomeController>(action => action.Welcome());
		}

		/// <summary>Creates the account.</summary>
		/// <param name="user">The user.</param>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[ActionName("Register")]
		public ActionResult CreateAccount(UnregisteredUser user)
		{
			if(!ModelState.IsValid) { return View(user); }

			UserLogin newUser = new UserLogin
			{
				Email = user.Email,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName
			};

			UserLogin userLogin = this.Service.CreateUser(newUser);

			// If user was not found, they already exist in the system with this email address.
			if(userLogin == null)
			{
				ModelState.AddModelError("", "User already exists with this email address.");
				return View(user);
			}

			IUserIdentity userData = new UserIdentity
			{
				AccountId = userLogin.AccountId,
				Email = userLogin.Email,
				FirstName = userLogin.FirstName,
				LastName = userLogin.LastName
			};

			MvcAuthentication.AuthenticateUser(userData);

			return this.RedirectToAction<HomeController>(action => action.Welcome());
		}

		/// <summary>Logs out the user.</summary>
		[Authorize]
		public new void Logout()
		{
			base.Logout();
		}
	}
}