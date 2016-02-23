'use strict';

Reload.UsingModules([
	'Reload.Filters.Helpers',
	'Reload.Web.Services',
	'Reload.Areas.Firearms.Services',
	'Reload.Areas.Firearms.Controllers'
]);

angular.module('FirearmManager', ['ngRoute', 'ngResource', 'ui.bootstrap', 'Authorization', 'blockUI', 'reload.ui'])
	.constant('templateUrl', '/areas/firearms/templates')
	.value('enumUrl', '/firearms/enums/get')
	.config(['$routeProvider', 'templateUrl', function (routing, templateUrl) {
		routing
			.when('/list', {
				templateUrl: templateUrl + '/list.html',
				controller: 'FirearmListController'
			})
			.when('/edit/:Id', {
				templateUrl: templateUrl + '/edit.html',
				controller: 'FirearmEditController'
			})
			.when('/new', {
				templateUrl: templateUrl + '/edit.html',
				controller: 'FirearmEditController'
			})
			.otherwise({ redirectTo: '/list' });
	}])
	.filter('EnumToString', Reload.Filters.Helpers.EnumToString)
	.service('FirearmEnumService', ['$resource', 'enumUrl', Reload.Web.Services.Enums])
	.service('FirearmService', ['$resource', Reload.Areas.Firearms.Services.WebService])
	.controller('FirearmEditController',
		['$scope', '$routeParams', '$location', 'FirearmService', 'FirearmEnumService', Reload.Areas.Firearms.Controllers.EditController]
	)
	.controller('FirearmListController',
		['$scope', '$location', 'FirearmService', 'FirearmEnumService', 'ConfirmDialog', Reload.Areas.Firearms.Controllers.ListController]
	);