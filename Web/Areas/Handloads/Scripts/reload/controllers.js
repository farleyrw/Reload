'use strict';

Reload.DefineNamespace('Reload.Areas.Handloads.Controllers', function () {
	/// The handload list controller.
	this.HandloadListController = function (scope, HandloadService, FirearmService, EnumService) {
		scope.Firearms = FirearmService.List();

		scope.Handloads = HandloadService.List();

		scope.click = function () {
			scope.SelectedFirearm = scope.Firearms[0];
		}

		scope.Enums = EnumService.Get();
	};

	/// The handload edit controller.
	this.HandloadEditController = function (scope, EnumService) {

		scope.Enums = EnumService.Get();
	};
});