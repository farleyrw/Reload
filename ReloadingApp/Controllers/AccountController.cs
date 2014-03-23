using System.Web.Mvc;
using MvcContrib;
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
			return this.RedirectToAction(action => action.Login(false));
		}

		/// <summary>The login view.</summary>
		[HttpGet]
		public ActionResult Login(bool? autoLogout = false)
		{
			if(this.Request.IsAuthenticated)
			{
				return this.RedirectToAction<HomeController>(action => action.Welcome());
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
				return this.RedirectToAction<HomeController>(action => action.Welcome());
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
			if(!ModelState.IsValid)
			{
				return View(user);
			}

			UserLogin userLogin = this.Service.GetUser(user.Email, user.Password);

			// If user was not found, bad credentials were given.
			if(userLogin == null)
			{
				ModelState.AddModelError("", "Invalid username or password.");
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

			if(Url.IsLocalUrl(returnUrl))
			{
				return this.Redirect(returnUrl);
			}

			return this.RedirectToAction<HomeController>(action => action.Welcome());
		}

		/// <summary>Creates the account.</summary>
		/// <param name="user">The user.</param>
		[HttpPost]
		[ActionName("Register")]
		public ActionResult CreateAccount(UnregisteredUser user)
		{
			if(!ModelState.IsValid)
			{
				return View(user);
			}

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

			UserIdentityData userData = new UserIdentityData
			{
				AccountId = userLogin.AccountId,
				Email = userLogin.Email,
				FirstName = userLogin.FirstName,
				LastName = userLogin.LastName
			};

			base.SaveAuthentication(userData);

			return this.RedirectToAction<HomeController>(action => action.Welcome());
		}

		/// <summary>Logs out the user.</summary>
		public new RedirectToRouteResult Logout()
		{
			return base.Logout();
		}
	}
}