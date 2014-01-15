
FirearmManager.controller("FirearmListController",
	["$scope", "FirearmService", "FirearmEnumService",
        function (scope, FirearmService, EnumService) {
        	scope.Firearms = FirearmService.List();

		    scope.$on("RefreshFirearmList", function () {
		    	scope.Firearms = FirearmService.List();
		    });

		    scope.Delete = FirearmService.Delete;

		    scope.Enums = EnumService.Get();
        }
	]
);