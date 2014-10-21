'use strict';

Reload.DefineNamespace('Reload.Providers.Authorization', function () {
	/// Provides http request authorization.
	this.RequestAuthorization = function (promise, window) {
		var ResponseStatus = {
			Unauthorized: 401
		};

		return {
			responseError: function (response) {
				// Force a reload on an unauthenticated request.
				if (response.status == ResponseStatus.Unauthorized) {
					window.alert("Your session has expired.");
					window.location.reload();
				}

				return response || promise.reject(response);
			}
		};
	};
});