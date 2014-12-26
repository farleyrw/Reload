using System.Web.Mvc;
using Reload.Common.Authentication;
using Reload.Common.Authentication.Mvc;
using Reload.Common.Interfaces.Services;
using Reload.Web.Controllers;

namespace Reload.Web.Areas.User.Controllers
{
	/// <summary>The account controller.</summary>
    public class ManageController : BaseController
    {
		private readonly IUserService Service;

		/// <summary>Initializes a new instance of the <see cref="ManageController"/> class.</summary>
		/// <param name="service">The service.</param>
		public ManageController(IUserService service)
		{
			this.Service = service;
		}

		/// <summary>The default view.</summary>
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult SaveUser(UserLogin user)
		{
			// Get user by current identity email.
			UserLogin userLogin = this.Service.GetUser(base.Identity.Email);

			// Since a form is not posted TryUpdateModel() cannot get the values.
			userLogin.Email = user.Email;
			userLogin.FirstName = user.FirstName;
			userLogin.LastName = user.LastName;

			this.Service.Save(userLogin);

			MvcAuthentication.AuthenticateUser(new UserIdentity
			{
				AccountId = this.Identity.AccountId,
				Email = userLogin.Email,
				FirstName = userLogin.FirstName,
				LastName = userLogin.LastName
			});

			return BaseController.GetJsonStatusResult(true, "User saved");
		}

		[HttpPost]
		public ActionResult SavePassword(string password, string confirmPassword)
		{
			UserLogin userLogin = this.Service.GetUser(base.Identity.Email);

			userLogin.Password = password;

			this.Service.Save(userLogin);

			return BaseController.GetJsonStatusResult(true, "Password saved");
		}

		[HttpPost]
		public ActionResult ValidateUniqueEmail(string email)
		{
			if(this.Identity.Email.Equals(email)) { return BaseController.GetJsonStatusResult(true); }

			return BaseController.GetJsonStatusResult(this.Service.IsEmailAvailable(email), "The email address is taken.");
		}
    }
}