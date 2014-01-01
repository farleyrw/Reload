
FirearmManager.controller("FirearmEditController",
	["$scope", "$routeParams", "$location", "FirearmEditService", "FirearmEnumService",
		function (scope, route, location, EditService, EnumService) {
			EditService.Get(route.Id, function (firearm) {
				scope.Firearm = firearm;
			});

			scope.Save = function () {
				EditService.Save(scope.Firearm, function () {
					location.path('/list');
				});
			};

			scope.IsValid = function () {
				return scope.Firearm &&
					scope.Firearm.Brand >= 0 &&
					scope.Firearm.Chamber >= 0 &&
					scope.Firearm.BarrelLength > 0;
			};

			scope.Enums = EnumService.Get();
		}
	]
);