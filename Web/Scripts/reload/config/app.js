
(function () {
	'use strict';

	angular.module('reload.config.app', [])
		.constant('appSettings', {
			IsDebug: '{IsDebug}' === 'true'
		})
		.config(['$compileProvider', '$logProvider', 'appSettings', function(compileProvider, logProvider, appSettings) {
			compileProvider.debugInfoEnabled(appSettings.IsDebug);

			logProvider.debugEnabled(appSettings.IsDebug);
		}]);
})();