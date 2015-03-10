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
				return ajax.post(baseUrl + 'ValidateUniqueEmail', { emailValidation: { Email: email } });
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
							ngModel.emailValidationErrorMessage = response.data.Message;
							return promise.reject(response.data.Message);
						}

						return true;
					});
				};
			}
		};
	};

	/// The password change dialog service.
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
						window.scope = scope;
						scope.Cancel = modalInstance.dismiss;
					}],
					templateUrl: baseUrl + 'ChangePassword'
				}).result;
			}
		};
	};

	/// The compare to control directive.
	this.CompareToControl = function () {
		// TODO: add inverted compare to old vs new password
		return {
			restrict: 'A',
			require: 'ngModel',
			scope: { // TODO: remove scope and read from attribute
				compareValue: '=compareTo'
			},
			link: function (scope, element, attributes, ngModel) {
				ngModel.$validators.compareTo = function (modelValue) {
					if (attributes.negate === true) {
						return modelValue != scope.compareValue;
					} else {
						return modelValue == scope.compareValue;
					}
				};

				scope.$watch('compareValue', function (newValue) {
					console.log(newValue);
					ngModel.$validate();
				});
				console.log(scope.compareValue);
				window.compareTo = { confirmpw: scope, newpw: ngModel };
			}
		};
	};
});