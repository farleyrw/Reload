'use strict';

FirearmManager.controller("FirearmListController",
	["$scope", "$location", "FirearmService", "FirearmEnumService",
        function (scope, location, FirearmService, EnumService) {
        	scope.Firearms = FirearmService.List();

        	scope.Add = function () {
        		location.path('/new');
        	};

        	scope.Delete = function (firearm) {
        		if (confirm("Are you sure you want to delete your " + firearm.Name + "?")) {
        			FirearmService.Delete(firearm, function (firearm) {
        				scope.Firearms.splice(scope.Firearms.indexOf(firearm), 1);
        			});
        		}
        	};

        	scope.Enums = EnumService.Get();
        }
	]
);