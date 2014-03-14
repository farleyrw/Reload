'use strict';

var HandloadManager = angular.module("HandloadManager", ['ngRoute', 'ngResource']);

HandloadManager.config(['$routeProvider', function (routing) {
	routing
        .when('/list', { templateUrl: '/areas/handloads/templates/list.html', controller: 'HandloadListController' })
        .when('/new', { templateUrl: '/areas/handloads/templates/edit.html', controller: 'HandloadEditController' })
        //.when('/edit/:Id', { templateUrl: '/areas/firearms/templates/edit.html', controller: 'FirearmEditController' })
        .otherwise({ redirectTo: '/list' });
}]);

// Filter to get the string value of the enum.
HandloadManager.filter("EnumToString", function () {
	return function (index, array) {
		return array ? array[index].Name : index;
	};
});
