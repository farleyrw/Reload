'use strict';

(function () {
	describe('Controller init', function () {
		var scope, controller, listServiceMock, firearms;

		beforeEach(function () {
			module('FirearmManager');

			inject(function ($rootScope, $controller, ListService, EnumService) {
				scope = $rootScope.$new();
				firearms = [{ id: 1 }];
				listServiceMock = sinon.stub(ListService);
				listServiceMock.List.returns(firearms);
				controller = $controller('FirearmListController', { $scope: scope });
			});
		});

		it('should set the firearm list', function () {
			expect(scope.firearms).toBe(firearms)
		});
	})
})();