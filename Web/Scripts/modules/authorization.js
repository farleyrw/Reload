'use strict';

Reload.IncludeModule('Reload.Angular.Providers');

angular.module('Authorization', [])
	.constant('LoginUrl', '/reload/account/logon')
	.config(['$httpProvider', function (httpProvider) {
		httpProvider.interceptors.push('AuthorizationService');
	}])
	.service('AuthorizationService', ['$q', '$location', 'LoginUrl', Reload.Angular.Providers.Authorization]);