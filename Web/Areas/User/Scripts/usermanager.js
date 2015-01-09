'use strict';

Reload.IncludeModule('Reload.Areas.User.Services');

angular.module('UserManager', ['ui.bootstrap', 'ngMessages'])
	.value('CurrentUser', angular.copy(CurrentUser))
	.value('baseUrl', '/Reload/User/Manage/')
	.service('UserService', ['$http', 'baseUrl', Reload.Areas.User.Services.UserService])
	.service('PasswordFormDialog', ['$modal', 'UserService', Reload.Areas.User.Services.PasswordChangeDialogService])
	.directive('emailUniqueValidator', ['$q', 'UserService', Reload.Areas.User.Services.UniqueEmailDirective])
	.controller('UserController', ['$scope', '$timeout', 'UserService', 'PasswordFormDialog', function (scope, timeout, UserService, PasswordChangeDialog) {
		UserService.Get(function (data) {
			scope.User = data;
		});

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
	}]);