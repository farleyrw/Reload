using System.Web.Mvc;
using System.Linq;
using Reload.Common.Authentication;
using Reload.Common.Authentication.Mvc;
using Reload.Common.Interfaces.Services;
using Reload.Web.Areas.User.Models;
using Reload.Web.Controllers;
using System.Collections.Generic;

namespace Reload.Web.Areas.User.Controllers
{
	/// <summary>The account controller.</summary>
	public class ManageController : BaseController
	{
		/// <summary>The user service.</summary>
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

		/// <summary>Gets the current user.</summary>
		public JsonResult Get()
		{
			return BaseController.GetJsonResult(this.User.Identity);
		}

		/// <summary>Saves the specified user.</summary>
		/// <param name="user">The user.</param>
		[HttpPost]
		public JsonResult Save(UserLogin user)
		{
			// Get user by current identity email.
			UserLogin userLogin = this.Service.GetUser(base.Identity.Email);

			// Since a form is not posted TryUpdateModel() cannot get the values.
			userLogin.Email = user.Email;
			userLogin.FirstName = user.FirstName;
			userLogin.LastName = user.LastName;
			userLogin.Password = user.Password;

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

		/// <summary>The change password partial view.</summary>
		/// <returns></returns>
		public ActionResult ChangePassword()
		{
			return PartialView();
		}

		/// <summary>Saves the password.</summary>
		/// <param name="passwords">The passwords.</param>
		[HttpPost]
		public JsonResult SavePassword(PasswordChangeViewModel passwords)
		{
			if(!ModelState.IsValid)
			{
				string validationMessage = ModelState.Values
					   .SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
					   .FirstOrDefault();

				return BaseController.GetJsonStatusResult(false, validationMessage);
			}

			UserLogin userLogin = this.Service.GetUser(base.Identity.Email);

			if(!userLogin.Password.Equals(passwords.OldPassword))
			{
				return BaseController.GetJsonStatusResult(false, "The old password is invalid.");
			}

			userLogin.Password = passwords.NewPassword;

			this.Service.Save(userLogin);

			return BaseController.GetJsonStatusResult(true);
		}

		/// <summary>Validates the unique email.</summary>
		/// <param name="emailValidation">The email validation model.</param>
		[HttpPost]
		public JsonResult ValidateUniqueEmail(EmailValidationViewModel emailValidation)
		{
			if(!ModelState.IsValid)
			{
				string validationMessage = ModelState.Values
					.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
					.FirstOrDefault();

				// This is to account for a difference in .Net vs Html5 email validation that does not require a complete TLD.
				return BaseController.GetJsonStatusResult(false, validationMessage);
			}

			// The email is the same as the current user (unchanged).
			if(this.Identity.Email.Equals(emailValidation.Email))
			{
				return BaseController.GetJsonStatusResult(true); 
			}

			if(!this.Service.IsEmailAvailable(emailValidation.Email))
			{
				return BaseController.GetJsonStatusResult(false, "The email address is taken.");
			}

			return BaseController.GetJsonStatusResult(true);
		}
	}
}