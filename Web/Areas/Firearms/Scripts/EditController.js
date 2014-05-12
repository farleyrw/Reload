'use strict';

FirearmManager.controller("FirearmEditController",
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
);