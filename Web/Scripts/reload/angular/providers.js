
Reload.DefineNamespace('Reload.Angular.Providers', function () {
	this.Authorization = function (provider, loginUrl) {
		// Add custom request interceptor.
		provider.interceptors.push(function () {
			return {
				responseError: function (response) {
					// Redirect to logon page on unauthenticated request.
					if (response.status == 401) {
						alert("Your session has expired. Please login again to continue.");
						window.location = loginUrl;
					}

					return response; // || promise.reject(response);
				}
			};
		});
	};
});