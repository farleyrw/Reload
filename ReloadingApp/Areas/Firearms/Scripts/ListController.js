
FirearmManager.controller("FirearmListController",
	["$scope", "FirearmListService", "FirearmEnumService",
        function (scope, ListService, EnumService) {
        	scope.Firearms = ListService.Get();

		    scope.$on("RefreshFirearmList", function () {
		    	scope.Firearms = ListService.Get();
		    });

		    scope.Delete = ListService.Delete;

		    EnumService.GetEnums().success(function (data) {
			    scope.Enums = data;
		    });
        }
	]
);