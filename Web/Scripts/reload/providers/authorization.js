
(function () {
	'use strict';

	angular.module('Authorization', [])
		.config(['$httpProvider', function (httpProvider) {
			httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
			httpProvider.interceptors.push('AuthorizationService');
		}])
		.factory('AuthorizationService', ['$q', '$window', function (promise, window) {
			var ResponseStatus = {
				Unauthorized: 401
			};

			return {
				responseError: function (response) {
					// Force a reload on an unauthenticated request.
					if (response.status === ResponseStatus.Unauthorized) {
						window.alert("Your session has expired.");
						window.location.reload();
					}

					return promise.reject(response);
				}
			};
		}]);
})();