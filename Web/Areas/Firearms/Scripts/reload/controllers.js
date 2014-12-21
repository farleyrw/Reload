'use strict';

Reload.DefineNamespace('Reload.Areas.Firearms.Controllers', function () {
	/// The firearm list controller.
	this.ListController = function (scope, location, FirearmService, EnumService, ConfirmDialog) {
		scope.Firearms = FirearmService.List();

		scope.Add = function () {
			location.path('/new');
		};

		scope.Edit = function (id) {
			location.path('/edit/' + id);
		};

		scope.Delete = function (firearm) {
			ConfirmDialog.Show(firearm.Name).then(function () {
				// TODO: switch to resource api $delete();
				FirearmService.Delete(firearm, function (firearm) {
					scope.Firearms.splice(scope.Firearms.indexOf(firearm), 1);
				});
			});
		};

		scope.Enums = EnumService.Get();
	};

	/// The firearm edit controller.
	this.EditController = function (scope, route, location, FirearmService, EnumService) {
		scope.Firearm = FirearmService.Get(route.Id);

		scope.Save = function () {
			FirearmService.Save(scope.Firearm, scope.BackToList);
		};

		scope.Enums = EnumService.Get();

		scope.BackToList = function () {
			location.path('/list');
		};
	};
});