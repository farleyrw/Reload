'use strict';

var FirearmManager = angular.module("FirearmManager", ['ngRoute', 'ngResource']);

FirearmManager.config(['$routeProvider', function (routing) {
	routing
        .when('/list', { templateUrl: '/areas/firearms/templates/list.html', controller: 'FirearmListController' })
        .when('/new', { templateUrl: '/areas/firearms/templates/edit.html', controller: 'FirearmEditController' })
        .when('/edit/:Id', { templateUrl: '/areas/firearms/templates/edit.html', controller: 'FirearmEditController' })
        .otherwise({ redirectTo: '/list' });
}]);

// Filter to get the string value of the enum.
FirearmManager.filter("EnumToString", function () {
	return function (index, array) {
		return array ? array[index].Name : index;
	};
});
