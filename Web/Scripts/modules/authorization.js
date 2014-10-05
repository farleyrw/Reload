'use strict';

Reload.IncludeModule('Reload.Providers.Authorization');

angular.module('Authorization', [])
	.constant('LoginUrl', '/reload/account/logon')
	.config(['$httpProvider', function (httpProvider) {
		httpProvider.interceptors.push('AuthorizationService');
	}])
	.service('AuthorizationService', ['$q', '$location', 'LoginUrl', Reload.Providers.Authorization.RequestAuthorization]);