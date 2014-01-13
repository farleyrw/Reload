'use strict';

var FirearmManager = angular.module("FirearmManager", ['ngRoute', 'ngResource'])
	.constant('templateUrl', 'areas/firearms/templates/')
	.config(['$routeProvider', 'templateUrl', function (routing, templateUrl) {
		routing
			.when('/list', { templateUrl: templateUrl + 'list.html', controller: 'FirearmListController' })
			.when('/new', { templateUrl: templateUrl + 'edit.html', controller: 'FirearmEditController' })
			.when('/edit/:Id', { templateUrl: templateUrl + 'edit.html', controller: 'FirearmEditController' })
			.otherwise({ redirectTo: '/list' });
	}
]);

// Filter to get the string value of the enum.
FirearmManager.filter("EnumToString", function () {
	return function (index, array) {
		return array ? array[index].Name : index;
	};
});
