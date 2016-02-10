
(function () {
	'use strict';

	angular.module('reload.config.http', [])
		.config(['$httpProvider', '$httpParamSerializerJQLikeProvider', function ($httpProvider, $httpParamSerializerJQLikeProvider) {
			$httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';

			$httpProvider.defaults.transformRequest.unshift($httpParamSerializerJQLikeProvider.$get());
		}]);
})();