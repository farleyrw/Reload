'use strict';

angular.module('Session', ['ngCookies'])
	.constant('LoginUrl', '/reload/account/logon')
	.service('AuthorizationService', ['$rootScope', '$cookies', '$location', 'LoginUrl', function (rootScope, cookies, location, loginUrl) {
		rootScope.$watch(function () { cookies.AuthTicket; }, function () {
			location.path(loginUrl);
		});
	}]);