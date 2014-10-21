'use strict';

angular.module('Session', ['ngCookies'])
	.constant('LoginUrl', '/reload/account/logon')
	.service('AuthorizationService', ['$rootScope', '$cookies', '$location', 'LoginUrl', function (rootScope, cookies, location, loginUrl) {
		rootScope.$watch(function () { cookies.AuthTicket; }, function () {
			//console.log('cookie value change', cookies.AuthTicket);

			if (angular.isUndefined(cookies.AuthTicket) || cookies.AuthTicket.length == 0) {
				//location.path(loginUrl);
			}
		});
	}]);