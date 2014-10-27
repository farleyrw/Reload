using System.Globalization;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Reload.Common.Helpers;

namespace Reload.Common.Authentication.Mvc
{
	/// <summary>The user indentity data.</summary>
	[XmlRoot("UserData"), KnownType(typeof(UserIdentity))]
	public class UserIdentityData : IUserIdentityData
	{
		/// <summary>Initializes a new instance of the <see cref="UserIdentityData"/> class.</summary>
		public UserIdentityData() { }

		/// <summary>Initializes a new instance of the <see cref="UserIdentityData"/> class.</summary>
		/// <param name="cookieData">The data.</param>
		public UserIdentityData(string cookieData)
		{
			if(string.IsNullOrWhiteSpace(cookieData)) { return; }

			UserIdentityData userData = XmlTransformHelper.Deserialize<UserIdentityData>(cookieData);

			if(userData != null)
			{
				this.Initialize(userData.AccountId, userData.Email, userData.FirstName, userData.LastName);
			}
		}

		/// <summary>Initializes a new instance of the <see cref="UserIdentityData"/> class.</summary>
		/// <param name="accountId">The account id.</param>
		/// <param name="email">The email.</param>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		public UserIdentityData(int accountId, string email, string firstName, string lastName)
		{
			this.Initialize(accountId, email, firstName, lastName);
		}

		/// <summary>Initializes the class.</summary>
		/// <param name="accountId">The account id.</param>
		/// <param name="email">The email.</param>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		private void Initialize(int accountId, string email, string firstName, string lastName)
		{
			this.AccountId = accountId;
			this.Email = email;
			this.FirstName = firstName;
			this.LastName = lastName;
		}

		/// <summary>Gets or sets the account id.</summary>
		/// <value>The account id.</value>
		[XmlAttribute]
		public int AccountId { get; set; }

		/// <summary>Gets or sets the email.</summary>
		/// <value>The email.</value>
		[XmlAttribute]
		public string Email { get; set; }

		/// <summary>Gets or sets the first name.</summary>
		/// <value>The first name.</value>
		[XmlAttribute]
		public string FirstName { get; set; }

		/// <summary>Gets or sets the last name.</summary>
		/// <value>The last name.</value>
		[XmlAttribute]
		public string LastName { get; set; }

		/// <summary>Gets the full name.</summary>
		/// <value>The full name.</value>
		[XmlIgnore]
		public string FullName
		{
			get { return string.Format(CultureInfo.InvariantCulture, "{0} {1}", this.FirstName, this.LastName); }
		}

		/// <summary>Determines whether this instance has data.</summary>
		/// <returns><c>true</c> if this instance has data; otherwise, <c>false</c>.</returns>
		public bool HasData()
		{
			if(this.AccountId == 0) { return false; }
			if(this.Email == string.Empty) { return false; }

			return true;
		}

		/// <summary>Returns a clone of the user data.</summary>
		public UserIdentityData GetUserData()
		{
			return new UserIdentityData(this.AccountId, this.Email, this.FirstName, this.LastName);
		}
	}
}