'use strict';

Reload.IncludeModules([
	'Reload.Angular.Filters',
	'Reload.Angular.Services',
	'Reload.Angular.Directives'
]);

angular.module('HandloadManager', ['ngRoute', 'ngResource', 'ui.bootstrap', 'Authorization'])
	.constant('templateUrl', '/reload/areas/handloads/templates/')
	.value('enumUrl', '/reload/handloads/enums/get')
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
	.service('HandloadService', ['$resource', function (ajax) {
		var api = ajax('handloads/manage/:action/:id', {
			action: '@action',
			id: '@id'
		}, {
			List: {
				method: 'GET',
				params: { action: 'getthem' },
				isArray: true
			},
			Delete: {
				method: 'POST',
				params: { action: 'delete' }
			},
			Edit: {
				method: 'GET',
				params: { action: 'edit', id: 'id' }
			},
			Save: {
				method: 'POST',
				params: { action: 'save' }
			}
		});

		return {
			List: api.List,
			Delete: function (firearm, callback) {
				api.Delete({ firearmId: firearm.FirearmId }, callback);
			},
			Get: function (firearmId) {
				return api.Edit({ id: firearmId || 0 });
			},
			Save: function (firearm, callback) {
				api.Save({ firearm: firearm }, callback);
			}
		};
	}])
	.controller('HandloadListController',
		['$scope', '$location', 'FirearmService', 'HandloadService', 'HandloadEnumService',
			function (scope, location, FirearmService, HandloadService, EnumService) {
				scope.Firearms = FirearmService.List();

				scope.Hanloads = HandloadService.List();

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
	Add sorting by useful parameters
*/