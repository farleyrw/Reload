'use strict';

Reload.IncludeModules([
	'Reload.Angular.Filters',
	'Reload.Angular.Providers',
	'Reload.Angular.Services',
	'Reload.Angular.Directives'
]);

angular.module("FirearmManager", ['ngRoute', 'ngResource', 'ui.bootstrap'])
	.constant('loginUrl', '/reload/account/logon')
	.constant('templateUrl', '/reload/areas/firearms/templates/')
	.value('enumUrl', '/reload/firearms/enum')
	.config(['$routeProvider', 'templateUrl', function (routing, templateUrl) {
		routing
			.when('/list', {
				templateUrl: templateUrl + 'list.html',
				controller: 'FirearmListController'
			})
			.when('/edit/:Id', {
				templateUrl: templateUrl + 'edit.html',
				controller: 'FirearmEditController'
			})
			.when('/new', {
				templateUrl: templateUrl + 'edit.html',
				controller: 'FirearmEditController'
			})
			.otherwise({ redirectTo: '/list' });
	}])
	.config(['$httpProvider', 'loginUrl', Reload.Angular.Providers.Authorization])
	.filter("EnumToString", Reload.Angular.Filters.EnumToString)
	.directive("modifyItemControl", Reload.Angular.Directives.ModifyItem)
	.controller("FirearmEditController",
		["$scope", "$routeParams", "$location", "FirearmService", "FirearmEnumService",
			function (scope, route, location, FirearmService, EnumService) {
				scope.Firearm = (route.Id) ? FirearmService.Get(route.Id) : {};

				scope.Save = function () {
					FirearmService.Save(scope.Firearm, scope.BackToList);
				};

				scope.Enums = EnumService.Get();

				scope.IsValid = function () {
					return scope.Firearm &&
						scope.Firearm.Chamber >= 0 &&
						scope.Firearm.BarrelLength > 0;
				};

				scope.BackToList = function () {
					location.path('/list');
				};
			}
		]
	)
	.controller("FirearmListController",
		["$scope", "$location", "FirearmService", "FirearmEnumService",
			function (scope, location, FirearmService, EnumService) {
        		scope.Firearms = FirearmService.List();

        		scope.Add = function () {
        			location.path('/new');
        		};

        		scope.Edit = function (id) {
        			location.path("/edit/" + id);
        		};

        		scope.Delete = function (firearm) {
        			if (confirm("Are you sure you want to delete your " + firearm.Name + "?")) {
        				FirearmService.Delete(firearm, function (firearm) {
        					scope.Firearms.splice(scope.Firearms.indexOf(firearm), 1);
        				});
        			}
        		};

        		scope.Enums = EnumService.Get();
			}
		]
	)
	.service("FirearmEnumService", ["$resource", "enumUrl", Reload.Angular.Services.Enums])
	.service("FirearmService", ["$resource", function (ajax) {
		var api = ajax('firearms/manage/:action/:id', {
			action: '@action',
			id: '@id'
		}, {
			List: {
				method: 'GET',
				params: { action: 'list' },
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
	}]);