'use strict';

Reload.IncludeModule('Reload.Angular.Providers');

angular.module('Authorization', [])
	.constant('LoginUrl', '/reload/account/logon')
	.service('AuthorizationService', ['$q', '$location', 'LoginUrl', Reload.Angular.Providers.Authorization]);