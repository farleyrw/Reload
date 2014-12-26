'use strict';

Reload.DefineNamespace('Reload.Areas.User.Services', function () {
	/// The user service.
	this.UserService = function (ajax) {
		var baseUrl = '/Reload/User/Manage/'
		return {
			SaveUser: function (user, callback) {
				return ajax.post(baseUrl + 'SaveUser', { user: user }).success(callback);
			},
			SavePassword: function (passwords, callback) {
				return ajax.post(baseUrl + 'SavePassword', passwords).success(callback);
			},
			ValidateEmail: function (email) {
				return ajax.post(baseUrl + 'ValidateUniqueEmail', { email: email });
			}
		}
	};

	/// The password change dialog service.
	this.PasswordChangeDialogService = function (modal, UserService) {
		return {
			Show: function () {
				return modal.open({
					size: 'sm',
					controller: ['$scope', '$modalInstance', function (scope, modalInstance) {
						scope.Password = '';
						scope.ConfirmPassword = '';

						scope.ValidatePasswords = function () {
							if (scope.Password.length >= 6 && scope.Password == scope.ConfirmPassword) { return true; }

							return false;
						};

						scope.Save = function () {
							var passwords = { password: scope.Password, confirmPassword: scope.ConfirmPassword };
							UserService.SavePassword(passwords, modalInstance.close);
						};

						scope.Cancel = modalInstance.dismiss;
					}],
					template:
						'<div class="modal-header"><h3 class="modal-title">Change password</h3></div>' +
						'<div class="modal-body">' +
							'<h3>Enter your new password</h3>' +
							'<p>' +
								'<label>Password</label>' +
								'<input class="form-control" ng-model="Password" type="password" required />' +
							'</p>' +
							'<p>' +
								'<label>Confirm Password</label>' +
								'<input class="form-control" ng-model="ConfirmPassword" type="password" required />' +
							'</p>' +
						'</div>' +
						'<div class="modal-footer">' +
							'<button class="btn btn-primary" ng-click="Save()" ng-disabled="!ValidatePasswords()">OK</button>' +
							'<button class="btn btn-warning" ng-click="Cancel()">Cancel</button>' +
						'</div>'
				}).result;
			}
		};
	};
});