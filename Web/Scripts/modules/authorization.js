'use strict';

Reload.UsingModule('Reload.Providers.Authorization');

angular.module('Authorization', [])
	.config(['$httpProvider', function (httpProvider) {
		httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
		httpProvider.interceptors.push('AuthorizationService');
	}])
	.factory('AuthorizationService', ['$q', '$window', Reload.Providers.Authorization.RequestAuthorization]);