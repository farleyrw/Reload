
FirearmManager.controller("FirearmEditController",
	["$scope", "$routeParams", "$location", "FirearmService", "FirearmEnumService",
		function (scope, route, location, FirearmService, EnumService) {
			scope.Firearm = FirearmService.Get(route.Id)
			
			scope.Save = function () {
				console.log(scope.Firearm);
				FirearmService.Save(scope.Firearm, function () {
					location.path('/list');
				});
			};
			
			/*scope.Save = function () {
				scope.Firearm.$save();
				//location.path('/list');
			};*/

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