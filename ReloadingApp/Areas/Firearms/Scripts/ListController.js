'use strict';

FirearmManager.controller("FirearmListController",
	["$scope", "$location", "FirearmService", "FirearmEnumService",
        function (scope, location, FirearmService, EnumService) {
        	scope.Firearms = FirearmService.List();

        	scope.Add = function () {
        		location.path('/new');
        	};

        	scope.Delete = function (firearm) {
        		FirearmService.Delete(firearm, function (firearm) {
        			scope.Firearms.splice(scope.Firearms.indexOf(firearm), 1);
        		});
        	};

        	scope.Enums = EnumService.Get();
        }
	]
);