'use strict';

Reload.IncludeModules([
	'Reload.Angular.Filters',
	'Reload.Angular.Providers',
	'Reload.Angular.Services',
	'Reload.Angular.Directives'
]);

angular.module('HandloadManager', ['ngRoute', 'ngResource', 'ui.bootstrap'])
	.value('enumUrl', '/reload/firearms/enums')
	.config(['$routeProvider', function (routing) {
		routing
			.when('/list', { templateUrl: 'areas/handloads/templates/list.html', controller: 'HandloadListController' })
			//.when('/new', { templateUrl: 'areas/handloads/templates/edit.html', controller: 'HandloadEditController' })
			//.when('/edit/:Id', { templateUrl: 'areas/handloads/templates/edit.html', controller: 'HandloadEditController' })
			.otherwise({ redirectTo: '/list' });
	}])
	.filter('EnumToString', Reload.Angular.Filters.EnumToString)
	.service('HandloadEnumService', ['$resource', 'enumUrl', Reload.Angular.Services.Enums])
	.service('FirearmService', ['$resource', Reload.Firearms.Service.FirearmService])
	.controller('HandloadListController',
		['$scope', '$location', 'FirearmService', 'HandloadEnumService',
			function (scope, location, FirearmService, EnumService) {
				scope.Firearms = FirearmService.List();

				scope.click = function () {
					scope.SelectedFirearm = scope.Firearms[0];
				}

				scope.Enums = EnumService.Get();
			}
		]);

/* TODO:
	Add handloads for a firearm
	Add handload result for a handload
	Add firearm filter for handload list
	Add sorting by all parameters
*/