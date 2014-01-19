
FirearmManager.controller("FirearmListController",
	["$scope", "FirearmService", "FirearmEnumService",
        function (scope, FirearmService, EnumService) {
        	scope.Firearms = FirearmService.List();

        	scope.Delete = function (firearm) {
        		FirearmService.Delete(firearm, function (firearm) {
        			scope.Firearms.splice(scope.Firearms.indexOf(firearm), 1);
        		});
        	};

        	scope.Enums = EnumService.Get();
        }
	]
);