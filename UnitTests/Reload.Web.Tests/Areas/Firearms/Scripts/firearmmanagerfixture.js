
/// <reference path="/../../web/scripts/vendor/angular/angular-route.js" />

/// <reference path="/../../web/scripts/reload/filters/helpers.js" />
/// <reference path="/../../web/scripts/reload/web/services.js" />
/// <reference path="/../../web/scripts/modules/authorization.js" />
/// <reference path="/../../web/areas/firearms/scripts/reload/services.js" />
/// <reference path="/../../web/areas/firearms/scripts/reload/controllers.js" />
/// <reference path="/../../web/areas/firearms/scripts/firearmmanager.js" />

describe('Firearm Manager tests', function () {
	angular.module('ui.bootstrap', []);
	angular.module('blockUI', []);
	angular.module('Authorization', []);
	angular.module('ngResource', []);
	angular.module('reload.ui', []);

	beforeEach(module('FirearmManager'));

	describe('FirearmListController', function () {
		var testEnum = { abc: '123' };
		var testFirearm = { FirearmId: 123 };

		beforeEach(inject(function ($rootScope, $controller, $location, $q) {
			this.ConfirmDialog = {
				Show: function () {
					return $q.when();
				}
			};

			this.FirearmService = {
				List: function () {
					return [testFirearm];
				},
				Delete: function (item, callback) {
					callback(item);
				}
			};

			this.EnumService = {
				Get: function () {
					return testEnum;
				}
			};

			this.location = $location;

			this.scope = $rootScope.$new();
			this.controller = $controller('FirearmListController', {
				$scope: this.scope,
				FirearmEnumService: this.EnumService,
				FirearmService: this.FirearmService,
				ConfirmDialog: this.ConfirmDialog
			});
		}));

		it('should create scope methods', function () {
			expect(this.scope.Firearms).toBeDefined();
			expect(this.scope.Add).toBeDefined();
			expect(this.scope.Edit).toBeDefined();
			expect(this.scope.Delete).toBeDefined();
		});

		it('should set Enums model', function () {
			expect(this.scope.Enums.abc).toBe(testEnum.abc);
		});

		it('should set Firearms', function () {
			expect(this.scope.Firearms[0].FirearmId).toBe(testFirearm.FirearmId);
		});

		it('should delete firearm', function () {
			this.scope.Delete(testFirearm);
			this.scope.$digest();

			expect(this.scope.Firearms).toEqual([]);
		});

		it('should navigate to add firearm route', function () {
			spyOn(this.location, 'path');

			this.scope.Add();

			expect(this.location.path).toHaveBeenCalledWith('/new');
		});

		it('should navigate to edit firearm route', function () {
			spyOn(this.location, 'path');

			this.scope.Edit(1);

			expect(this.location.path).toHaveBeenCalledWith('/edit/1');
		});
	});
});