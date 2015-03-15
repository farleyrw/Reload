'use strict';

Reload.DefineNamespace('Reload.Areas.User.Services', function () {
	/// The user web service.
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
					// TODO: fix OriginalEmail parent scope dependency.
					if (!modelValue || scope.OriginalEmail == modelValue) {
						return promise.when();
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

						scope.Cancel = modalInstance.dismiss;
					}],
					templateUrl: baseUrl + 'ChangePassword'
				}).result;
			}
		};
	};

	/// The compare to control directive.
	this.CompareToControl = function ($parse) {
		return {
			restrict: 'A',
			require: 'ngModel',
			link: function (scope, element, attributes, ngModel) {
				var compare = $parse(attributes.compareTo);

				ngModel.$validators.compareTo = function (modelValue) {
					var compareValue = compare(scope);

					if (typeof compareValue == 'undefined' || typeof modelValue == 'undefined') {
						return true;
					}

					if (attributes.negate === 'true') {
						return modelValue != compareValue;
					} else {
						return modelValue == compareValue;
					}
				};

				scope.$watchGroup([
						function () { return compare(scope); },
						function () { return ngModel.$modelValue; }
					],
					function () { ngModel.$validate(); }
				);
			}
		};
	};
});