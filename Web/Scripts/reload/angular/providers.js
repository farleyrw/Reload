'use strict';

Reload.DefineNamespace('Reload.Angular.Providers', function () {
	// Provides http request authorization.
	this.Authorization = function (provider, loginUrl) {
		var ResponseStatus = {
			Unauthorized: 401
		};

		// Add custom request interceptor.
		provider.interceptors.push(function () {
			return {
				responseError: function (response) {
					// Redirect to logon page on unauthenticated request.
					if (response.status == ResponseStatus.Unauthorized) {
						alert("Your session has expired. Please login again to continue.");
						window.location = loginUrl;
					}

					return response; // || promise.reject(response);
				}
			};
		});
	};
});