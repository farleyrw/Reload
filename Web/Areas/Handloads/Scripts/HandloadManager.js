'use strict';

Reload.UsingModules([
	'Reload.Filters.Helpers',
	'Reload.Web.Services',
	'Reload.Ui.Controls',
	'Reload.Ui.Effects',
	'Reload.Ui.Widgets',
	'Reload.Areas.Firearms.Services',
	'Reload.Areas.Handloads.Services',
	'Reload.Areas.Handloads.Controllers'
]);

angular.module('HandloadManager', ['ngRoute', 'ngResource', 'ui.bootstrap', 'Authorization', 'blockUI'])
	.constant('templateUrl', '/reload/areas/handloads/templates/')
	.value('enumUrl', '/reload/handloads/enums/get')
	.config(['$routeProvider', 'templateUrl', function (routing, templateUrl) {
		routing
			.when('/list', { templateUrl: templateUrl + 'list.html', controller: 'HandloadListController' })
			.when('/new', { templateUrl: templateUrl + 'edit.html', controller: 'HandloadEditController' })
			.when('/edit/:Id', { templateUrl: templateUrl + 'edit.html', controller: 'HandloadEditController' })
			.otherwise({ redirectTo: '/list' });
	}])
	.filter('EnumToString', Reload.Filters.Helpers.EnumToString)
	.service('HandloadEnumService', ['$resource', 'enumUrl', Reload.Web.Services.Enums])
	.service('FirearmService', ['$resource', Reload.Areas.Firearms.Services.WebService])
	.service('HandloadService', ['$resource', Reload.Areas.Handloads.Services.HandloadService])
	.controller('HandloadListController', ['$scope', 'HandloadService', 'FirearmService', 'HandloadEnumService',
		Reload.Areas.Handloads.Controllers.HandloadListController
	])
	.controller('HandloadEditController', ['$scope', Reload.Areas.Handloads.Controllers.HandloadEditController]);

/* TODO:
	Add handloads for a firearm
	Add handload result for a handload
	Add firearm filter for handload list
	Add sorting by useful parameters
*/