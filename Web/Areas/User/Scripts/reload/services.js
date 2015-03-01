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
	this.PasswordChangeDialogService = function (modal, UserService) {
		return {
			Show: function () {
				return modal.open({
					size: 'sm',
					controller: ['$scope', '$modalInstance', function (scope, modalInstance) {
						scope.SavePending = false;
						scope.OldPassword = '';
						scope.NewPassword = '';
						scope.ConfirmPassword = '';

						scope.Save = function () {
							scope.SavePending = true;

							var passwords = {
								oldPassword: scope.OldPassword,
								newPassword: scope.NewPassword,
								confirmPassword: scope.ConfirmPassword
							};

							UserService.SavePassword({ passwords: passwords }, function (data) {
								if (data.Success) {
									modalInstance.close();
								} else {
									scope.SavePending = false;
									alert(data.Message); // TODO: fix alert from showing on cancel.
								}
							});
						};

						scope.Cancel = modalInstance.dismiss;
					}],
					template: // TODO: move this into razor view. TODO: add inverted compare to old vs new password
						'<div class="modal-header"><h3 class="modal-title">Change password</h3></div>' +
						'<form name="PasswordForm" ng-submit="Save()" novalidate>' +
							'<div class="modal-body">' +
								'<p>' +
									'<label>Old Password</label>' +
									'<input class="form-control" type="password" name="OldPassword" ng-model="OldPassword" required />' +
									'<div ng-if="PasswordForm.OldPassword.$dirty" ng-messages="PasswordForm.OldPassword.$error">' +
										'<span ng-message="required">The old password is required</span>' +
									'</div>' +
								'</p>' +
								'<p>' +
									'<label>New Password</label>' +
									'<input class="form-control" type="password" name="NewPassword" ng-model="NewPassword" minlength="6" required />' +
									'<div ng-if="PasswordForm.NewPassword.$dirty" ng-messages="PasswordForm.NewPassword.$error">' +
										'<span ng-message="required">The new password is required</span>' +
										'<span ng-message="minlength">The new password must be at least 6 characters</span>' +
									'</div>' +
								'</p>' +
								'<p>' +
									'<label>Confirm Password</label>' +
									'<input class="form-control" type="password" name="ConfirmPassword" ng-model="ConfirmPassword" compare-to="NewPassword" required />' +
									'<div ng-if="PasswordForm.ConfirmPassword.$dirty" ng-messages="PasswordForm.ConfirmPassword.$error">' +
										'<span ng-message="required">The confirm password is required</span>' +
										'<span ng-message="compareTo">The new and confirm password do not match</span>' +
									'</div>' +
								'</p>' +
							'</div>' +
							'<div class="modal-footer">' +
								'<button class="btn btn-primary" type="submit" ng-disabled="PasswordForm.$invalid || SavePending">OK</button>' +
								'<button class="btn btn-warning" ng-click="Cancel()">Cancel</button>' +
							'</div>' +
						'</form>'
				}).result;
			}
		};
	};

	/// The compare to control directive.
	this.CompareToControl = function () {
		return {
			restrict: 'A',
			require: 'ngModel',
			scope: { // TODO: remove scope and read from attribute
				compareTo: '='
			},
			link: function (scope, element, attribute, ngModel) {
				scope.$watchGroup(['compareTo', function () { return ngModel.$viewValue; }], function (newValues) {
					var compareValue = newValues[0] || '';
					var thisValue = newValues[1] || '';

					ngModel.$setValidity('compareTo', thisValue == compareValue);
				});
			}
		};
	};
});