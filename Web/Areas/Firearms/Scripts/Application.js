'use strict';

var FirearmManager = angular.module("FirearmManager", ['ng', 'ngRoute', 'ngResource', 'ui.bootstrap'])
	.constant('loginUrl', '/account/logon')
	.constant('templateUrl', 'areas/firearms/templates/')
	.config(['$routeProvider', 'templateUrl', function (routing, templateUrl) {
		routing
			.when('/list', { templateUrl: templateUrl + 'list.html', controller: 'FirearmListController' })
			.when('/new', { templateUrl: templateUrl + 'edit.html', controller: 'FirearmEditController' })
			.when('/edit/:Id', { templateUrl: templateUrl + 'edit.html', controller: 'FirearmEditController' })
			.otherwise({ redirectTo: '/list' });
	}])
	.config(['$httpProvider', 'loginUrl', function (provider, loginUrl) {
		// Add custom request interceptor.
		provider.interceptors.push(function () {
			return {
				responseError: function (response) {
					console.log('unathenticated', response);
					// Redirect to logon page on unauthenticated request.
					if (response.status == 401) {
						alert("Your session has expired. Please login again to continue.");
						window.location = loginUrl;
					}
					return response; // || promise.reject(response);
				}
			};
		});
	}]);

// Filter to get the string value of the enum.
FirearmManager.filter("EnumToString", function () {
	return function (index, array) {
		return array ? array[index].Name : index;
	};
});