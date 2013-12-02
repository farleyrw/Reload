
FirearmManager.controller("FirearmListController",
	["$scope", "FirearmListService", "FirearmEnumService",
        function (scope, ListService, EnumService) {
		    ListService.Get(function (firearms) {
			    scope.Firearms = firearms;
		    });

		    scope.$on("RefreshFirearmList", function () {
			    ListService.Get(function (firearms) {
				    scope.Firearms = firearms;
			    });
		    });

		    scope.Delete = ListService.Delete;

		    EnumService.GetEnums().success(function (data) {
			    scope.Enums = data;
		    });
        }
	]
);