'use strict';

Reload.IncludeModules([
	'Reload.Angular.Filters',
	'Reload.Angular.Services',
	'Reload.Angular.Directives'
]);

angular.module('FirearmManager', ['ngRoute', 'ngResource', 'ui.bootstrap', 'Authorization'])
	.constant('templateUrl', '/reload/areas/firearms/templates/')
	.value('enumUrl', '/reload/firearms/enums')
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
	.service('ModalService', ['$modal', function (modal) {
		this.Confirm = function (name) {
			return modal.open({
				template:
					'<div class="modal-header"><h3 class="modal-title">Confirm</h3></div>' +
					'<div class="modal-body">Are you sure you want to delete your {{ Name }}?</div>' +
					'<div class="modal-footer">' +
						'<button class="btn btn-primary" ng-click="Confirm()">OK</button>' +
						'<button class="btn btn-warning" ng-click="Cancel()">Cancel</button>' +
					'</div>',
				controller: function ($scope, $modalInstance) {
					$scope.Name = name;

					$scope.Confirm = $modalInstance.close;

					$scope.Cancel = $modalInstance.dismiss;
				},
				size: 'sm'
			}).result;
		};
	}])
	.controller('FirearmListController',
		['$scope', '$location', 'FirearmService', 'FirearmEnumService', 'ModalService',
			function (scope, location, FirearmService, EnumService, ModalService) {
        		scope.Firearms = FirearmService.List();

        		scope.Add = function () {
        			location.path('/new');
        		};

        		scope.Edit = function (id) {
        			location.path('/edit/' + id);
        		};

        		scope.Delete = function(firearm) {
        			ModalService.Confirm(firearm.Name).then(function () {
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