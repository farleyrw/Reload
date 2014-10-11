'use strict';

Reload.DefineNamespace('Reload.Providers.Authorization', function () {
	/// Provides http request authorization.
	this.RequestAuthorization = function (promise, location, loginUrl) {
		var ResponseStatus = {
			Unauthorized: 401
		};

		return {
			responseError: function (response) {
				// Redirect to logon page on unauthenticated request.
				if (response.status == ResponseStatus.Unauthorized) {
					alert("Your session has expired. Please login again to continue.");
					location.path(loginUrl);
				}

				return response || promise.reject(response);
			}
		};
	};

	this.CookieAuthorization = function () {

	};
});