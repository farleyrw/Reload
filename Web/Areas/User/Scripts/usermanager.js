'use strict';

Reload.IncludeModule('Reload.Areas.User.Services');

angular.module('UserManager', ['ui.bootstrap'])
	.value('CurrentUser', angular.copy(CurrentUser))
	.service('UserService', ['$http', Reload.Areas.User.Services.UserService])
	.service('PasswordFormDialog', ['$modal', 'UserService', Reload.Areas.User.Services.PasswordChangeDialogService])
	.controller('UserController', ['$scope', '$timeout', 'CurrentUser', 'UserService', 'PasswordFormDialog', function (scope, timeout, CurrentUser, UserService, PasswordChangeDialog) {
		scope.User = CurrentUser;

		scope.PasswordSaved = false;

		scope.ResetForm = function () {
			scope.UserForm.$setPristine();
		};

		scope.Save = function () {
			UserService.SaveUser(scope.User, scope.ResetForm);
		};

		scope.ChangePassword = function () {
			PasswordChangeDialog.Show().then(function () {
				scope.PasswordSaved = true;

				timeout(function () { scope.PasswordSaved = false; }, 3000);
			});
		};

		scope.ModelValidateOptions = {
			debounce: { default : 500 }
		};

		scope.FormValidation = function () {
			return scope.UserForm.$invalid || scope.UserForm.$pristine || scope.UserForm.$pending;
		};
	}])
	.directive('emailUniqueValidator', ['$q', 'UserService', function (promise, UserService) {
		return {
			require: 'ngModel',
			link: function (scope, element, attributes, ngModel) {
				ngModel.$asyncValidators.emailAvailable = function (modelValue, viewValue) {
					return UserService.ValidateEmail(viewValue).then(function (response) {
						if (!response.data.Success) {
							return promise.reject(response.data.Message);
						}

						return true;
					});
				};
			}
		};
	}]);