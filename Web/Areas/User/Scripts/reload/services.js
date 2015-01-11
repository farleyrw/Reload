'use strict';

Reload.DefineNamespace('Reload.Areas.User.Services', function () {
	/// The user service.
	this.UserService = function (ajax, baseUrl) {
		return {
			Get: function(callback) {
				return ajax.get(baseUrl + 'Get').success(callback);
			},
			SaveUser: function (user, callback) {
				return ajax.post(baseUrl + 'Save', { user: user }).success(callback);
			},
			SavePassword: function (passwords, callback) {
				return ajax.post(baseUrl + 'SavePassword', passwords).success(callback);
			},
			ValidateEmail: function (email) {
				return ajax.post(baseUrl + 'ValidateUniqueEmail', { email: email });
			}
		};
	};

	/// The unique email directive.
	this.UniqueEmailDirective = function (promise, UserService) {
		return {
			require: 'ngModel',
			link: function (scope, element, attributes, ngModel) {
				ngModel.$asyncValidators.emailAvailable = function (modelValue, viewValue) {
					if (!modelValue || scope.OriginalEmail == modelValue) {
						var empty = promise.defer();

						empty.resolve(function () { return true; });

						return empty.promise;
					}

					return UserService.ValidateEmail(modelValue).then(function (response) {
						if (!response.data.Success) {
							return promise.reject(response.data.Message);
						}

						return true;
					});
				};
			}
		};
	};

	/// The password change dialog service.
	this.PasswordChangeDialogService = function (modal, UserService) {
		return {
			Show: function () {
				return modal.open({
					size: 'sm',
					controller: ['$scope', '$modalInstance', function (scope, modalInstance) {
						scope.SavePending = false;
						scope.Password = '';
						scope.ConfirmPassword = '';

						scope.ValidatePasswords = function () {
							if (scope.Password && scope.Password.length >= 6 && scope.Password == scope.ConfirmPassword) {
								return true;
							}

							return false;
						};

						scope.Save = function () {
							scope.SavePending = true;
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
							'<button class="btn btn-primary" ng-click="Save()" ng-disabled="!ValidatePasswords() || SavePending">OK</button>' +
							'<button class="btn btn-warning" ng-click="Cancel()">Cancel</button>' +
						'</div>'
				}).result;
			}
		};
	};
});