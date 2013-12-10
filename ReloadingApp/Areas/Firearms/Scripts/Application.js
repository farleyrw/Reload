'use strict';

var FirearmManager = angular.module("FirearmManager", ['ngRoute', 'ngResource']);

FirearmManager.config(['$routeProvider', function (routing) {
	routing
        .when('/list', { templateUrl: '/firearms/view/list', controller: 'FirearmListController' })
        .when('/new', { templateUrl: '/firearms/view/edit', controller: 'FirearmEditController' })
        .when('/edit/:Id', { templateUrl: '/firearms/view/edit', controller: 'FirearmEditController' })
        .otherwise({ redirectTo: '/list' });
}]);

// Filter to get the string value of the enum.
FirearmManager.filter("EnumToString", function () {
	return function (index, array) {
		return array ? array[index].Name : index;
	};
});
