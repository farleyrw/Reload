﻿'use strict';

Reload.IncludeModules([
	'Reload.Filters.Helpers',
	'Reload.Web.Services',
	'Reload.Ui.Controls',
	'Reload.Ui.Effects',
	'Reload.Ui.Widgets',
	'Reload.Areas.Firearms.Services'
]);

angular.module('FirearmManager', ['ngRoute', 'ngResource', 'ui.bootstrap', 'Authorization', 'blockUI'])
	.constant('templateUrl', '/reload/areas/firearms/templates/')
	.value('enumUrl', '/reload/firearms/enums/get')
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
	.filter('EnumToString', Reload.Filters.Helpers.EnumToString)
	.service('ConfirmDialog', ['$modal', Reload.Ui.Widgets.ConfirmDialog])
	.service('FirearmEnumService', ['$resource', 'enumUrl', Reload.Web.Services.Enums])
	.service('FirearmService', ['$resource', Reload.Areas.Firearms.Services.WebService])
	.directive('modifyItemControl', Reload.Ui.Controls.ModifyItem)
	.directive('hoverHighlight', Reload.Ui.Effects.HoverHighlight)
	.controller('FirearmEditController',
		['$scope', '$routeParams', '$location', 'FirearmService', 'FirearmEnumService',
			function (scope, route, location, FirearmService, EnumService) {
				scope.Firearm = FirearmService.Get(route.Id);
				
				scope.Save = function () {
					FirearmService.Save(scope.Firearm, scope.BackToList);
				};

				scope.Enums = EnumService.Get();

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