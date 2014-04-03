'use strict';

FirearmManager.controller("FirearmEditController",
	["$scope", "$routeParams", "$location", "FirearmService", "FirearmEnumService",
		function (scope, route, location, FirearmService, EnumService) {
			scope.Firearm = FirearmService.Get(route.Id)
			
			scope.Save = function () {
				FirearmService.Save(scope.Firearm, function () {
					location.path('/list');
				});
			};
			
			scope.Enums = EnumService.Get();

			scope.IsValid = function () {
				return scope.Firearm &&
					scope.Firearm.Chamber >= 0 &&
					scope.Firearm.BarrelLength > 0;
			};
		}
	]
);