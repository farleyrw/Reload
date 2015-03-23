'use strict';

Reload.IncludeModules([
	'Reload.Areas.User.Services',
	'Reload.Areas.User.Directives'
]);

angular.module('UserManager', ['ui.bootstrap', 'ngMessages'])
	.constant('baseUrl', '/Reload/User/Manage/')
	.service('UserService', ['$http', 'baseUrl', Reload.Areas.User.Services.UserService])
	.service('PasswordFormDialog', ['$modal', 'baseUrl', 'UserService', Reload.Areas.User.Services.PasswordChangeDialogService])
	.directive('emailUniqueValidator', ['$q', 'UserService', Reload.Areas.User.Directives.UniqueEmail])
	.directive('compareTo', ['$parse', Reload.Areas.User.Directives.CompareTo])
	.controller('UserController', ['$scope', '$timeout', 'UserService', 'PasswordFormDialog',
		function (scope, timeout, UserService, PasswordChangeDialog) {
			UserService.Get(function (data) {
				scope.User = data;
				scope.OriginalEmail = scope.User.Email;
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
		}
	]);