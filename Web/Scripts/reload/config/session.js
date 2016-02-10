
(function () {
	'use strict';

	angular.module('reload.config.session', ['ngIdle'])
		.config(['IdleProvider', 'KeepaliveProvider', function (IdleProvider, KeepaliveProvider) {
			// configure Idle settings
			IdleProvider.idle(5);
			IdleProvider.timeout(5);
			KeepaliveProvider.interval(2);
		}])
		.run(['Idle', function (Idle) {
			Idle.watch();
		}]);
})();