
FirearmManager.controller("FirearmEditController",
	["$scope", "$routeParams", "$location", "FirearmEditService", "FirearmEnumService",
		function (scope, route, location, EditService, EnumService) {
			scope.Firearm = EditService.Get(route.Id)

			scope.Save = function () {
				EditService.Save(scope.Firearm, function () {
					location.path('/list');
				});
			};

			scope.Enums = EnumService.Get();

			scope.IsValid = function () {
				return scope.Firearm &&
					scope.Firearm.Brand >= 0 &&
					scope.Firearm.Chamber >= 0 &&
					scope.Firearm.BarrelLength > 0;
			};
		}
	]
);