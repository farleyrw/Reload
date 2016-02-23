'use strict';

Reload.DefineNamespace('Reload.Areas.User.Services', function () {
	/// The user web service.
	this.UserService = function (ajax, baseUrl) {
		return {
			Get: function() {
				return ajax.get(baseUrl + 'Get');
			},
			SaveUser: function (user, callback) {
				return ajax.post(baseUrl + 'Save', { user: user }).success(callback);
			},
			SavePassword: function (passwords, callback) {
				return ajax.post(baseUrl + 'SavePassword', passwords).success(callback);
			},
			ValidateEmail: function (email) {
				return ajax.post(baseUrl + 'ValidateUniqueEmail', { emailValidation: { Email: email } });
			}
		};
	};

	/// A dialog for changing a password.
	this.PasswordChangeDialogService = function (modal, baseUrl, UserService) {
		return {
			Show: function () {
				return modal.open({
					size: 'sm',
					controller: ['$scope', '$modalInstance', function (scope, modalInstance) {
						scope.SavePending = false;
						scope.Passwords = {
							Old: '',
							New: '',
							Confirm: ''
						};

						scope.Save = function () {
							scope.SavePending = true;

							var passwords = {
								oldPassword: scope.Passwords.Old,
								newPassword: scope.Passwords.New,
								confirmPassword: scope.Passwords.Confirm
							};

							UserService.SavePassword({ passwords: passwords }, function (data) {
								if (data.Success) {
									modalInstance.close();
								} else {
									scope.SavePending = false;

									scope.ErrorMessage = data.Message;
								}
							});
						};

						scope.Cancel = modalInstance.dismiss;
					}],
					templateUrl: baseUrl + 'ChangePassword'
				}).result;
			}
		};
	};
});