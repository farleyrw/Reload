using System.Web.Mvc;
using Reload.Common.Authentication;
using Reload.Common.Authentication.Mvc;
using Reload.Service.Interfaces;
using Reload.Service.Services;
using ReloadingApp.Models.Account;

namespace ReloadingApp.Controllers
{
	/// <summary>The account controller.</summary>
	[AllowAnonymous]
	public class AccountController : BaseController
	{
		/// <summary>The service.</summary>
		private readonly IUserService Service;

		/// <summary>Initializes a new instance of the <see cref="AccountController"/> class.</summary>
		public AccountController() : this(new UserService()) { }

		/// <summary>Initializes a new instance of the <see cref="AccountController"/> class.</summary>
		/// <param name="service">The service.</param>
		public AccountController(IUserService service)
		{
			this.Service = service;
		}

		/// <summary>Gets the index view result, default login page.</summary>
		public RedirectToRouteResult Index()
		{
			return this.RedirectToAction("Login");
		}

		/// <summary>The login view.</summary>
		[HttpGet]
		public ActionResult Login(bool? autoLogout)
		{
			if(this.Request.IsAuthenticated)
			{
				return this.RedirectToAction("Welcome", "Home");
			}

			base.DeleteFormsAuthentication();

			ViewBag.AutoLogout = autoLogout.GetValueOrDefault(false);

			return View();
		}

		/// <summary>The register view.</summary>
		[HttpGet]
		public ActionResult Register()
		{
			// TODO: remove this duplication.
			if(this.Request.IsAuthenticated)
			{
				return this.RedirectToAction("Welcome", "Home");
			}

			base.DeleteFormsAuthentication();

			return View();
		}

		/// <summary>Authenticates the specified user.</summary>
		/// <param name="user">The user.</param>
		/// <param name="returnUrl">The return URL.</param>
		[HttpPost]
		[ActionName("Login")]
		public ActionResult Authenticate(User user, string returnUrl)
		{
			UserLogin userLogin = this.Service.GetUser(user.Email, user.Password);

			// If user was not found, bad credentials were given.
			if(userLogin == null)
			{
				ModelState.AddModelError("", "User not found.");
				return View(user);
			}

			UserIdentityData userData = new UserIdentityData
			{
				AccountId = userLogin.AccountId,
				Email = userLogin.Email,
				FirstName = userLogin.FirstName,
				LastName = userLogin.LastName
			};

			base.SaveAuthentication(userData);

			if(this.IsLocalUrl(returnUrl))
			{
				return this.Redirect(returnUrl);
			}

			return this.RedirectToAction("Welcome", "Home");
		}

		/// <summary>Creates the account.</summary>
		/// <param name="user">The user.</param>
		/// <param name="returnUrl">The return URL.</param>
		[HttpPost]
		[ActionName("Register")]
		public ActionResult CreateAccount(UnregisteredUser user, string returnUrl)
		{
			UserLogin newUser = new UserLogin
			{
				Email = user.Email,
				Password = user.Password,
				FirstName = user.FirstName,
				LastName = user.LastName
			};

			UserLogin userLogin = this.Service.CreateUser(newUser);

			// If user was not found, they were not saved.
			if(userLogin == null)
			{
				ModelState.AddModelError("", "User not found.");
				return View(user);
			}

			UserIdentityData userData = new UserIdentityData
			{
				AccountId = userLogin.AccountId,
				Email = userLogin.Email,
				FirstName = userLogin.FirstName,
				LastName = userLogin.LastName
			};

			base.SaveAuthentication(userData);

			return this.RedirectToAction("Welcome", "Home");
		}

		/// <summary>Logs out the user.</summary>
		public new RedirectToRouteResult Logout()
		{
			return base.Logout();
		}

		/// <summary>Determines whether [is local URL] [the specified URL].</summary>
		/// <param name="url">The URL.</param>
		/// <returns><c>true</c> if [is local URL] [the specified URL]; otherwise, <c>false</c>.</returns>
		private bool IsLocalUrl(string url)
		{
			return Url.IsLocalUrl(url);
		}
	}
}