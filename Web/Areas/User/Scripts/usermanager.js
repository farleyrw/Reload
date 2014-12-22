'use strict';

angular.module('UserManager', [])
	.value('CurrentUser', CurrentUser)
	.service('UserService', function ($http) {
		return {
			Save: function (user, callback) {
				return $http.post('Save', { user: user }).success(callback);
			}
		}
	})
	.controller('UserController', ['$scope', 'CurrentUser', 'UserService', function (scope, CurrentUser, UserService) {
		scope.User = angular.copy(CurrentUser);

		scope.Save = function () {
			console.log('Saving, yah yah yah');
			scope.UserForm.$setPristine();
		};
	}]);