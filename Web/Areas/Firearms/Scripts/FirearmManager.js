﻿'use strict';

Reload.IncludeModules([
	'Reload.Angular.Filters',
	'Reload.Angular.Services',
	'Reload.Angular.Directives'
]);

angular.module('FirearmManager', ['ngRoute', 'ngResource', 'ui.bootstrap', 'Authorization'])
	.constant('templateUrl', '/reload/areas/firearms/templates/')
	.value('enumUrl', '/reload/firearms/enums/get')
	.config(['$httpProvider', function (httpProvider) {
		httpProvider.interceptors.push('AuthorizationService');
	}])
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
	.filter('EnumToString', Reload.Angular.Filters.EnumToString)
	.service('ConfirmDialog', ['$modal', Reload.Angular.Services.ConfirmDialog])
	.service('FirearmEnumService', ['$resource', 'enumUrl', Reload.Angular.Services.Enums])
	.service('FirearmService', ['$resource', Reload.Firearms.Service.FirearmService])
	.directive('modifyItemControl', Reload.Angular.Directives.ModifyItem)
	.controller('FirearmEditController',
		['$scope', '$routeParams', '$location', 'FirearmService', 'FirearmEnumService',
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
	.controller('FirearmListController',
		['$scope', '$location', 'FirearmService', 'FirearmEnumService', 'ConfirmDialog',
			function (scope, location, FirearmService, EnumService, ConfirmDialog) {
        		scope.Firearms = FirearmService.List();

        		scope.Add = function () {
        			location.path('/new');
        		};

        		scope.Edit = function (id) {
        			location.path('/edit/' + id);
        		};

        		scope.Delete = function(firearm) {
        			ConfirmDialog.Show(firearm.Name).then(function () {
						// TODO: switch to resource api $delete();
        				FirearmService.Delete(firearm, function (firearm) {
        					scope.Firearms.splice(scope.Firearms.indexOf(firearm), 1);
        				});
        			});
        		};

        		scope.Enums = EnumService.Get();
			}
		]
	);