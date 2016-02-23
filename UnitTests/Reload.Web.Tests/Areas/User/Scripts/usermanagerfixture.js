/// <reference path="usermanagerfixture_globals.js" />
/// <reference path="../../../../../web/areas/user/scripts/usermanager.js" />

describe('user manager', function () {
	beforeEach(function () {
		angular.module('ngMessages', []);
		angular.module('ui.bootstrap', [])
			.service('$modal', angular.noop);
	});

	beforeEach(module('UserManager'));

	beforeEach(inject(function (UserService, $q) {
		this.UserService = UserService;

		this.UserService.Get.and.callFake(function () {
			return $q.when({ data: { Email: 'xyz' } });
		});
	}));

	beforeEach(inject(function ($controller, $rootScope) {
		this.scope = $rootScope.$new();
		this.controller = $controller('UserController', {
			$scope: this.scope
		});
	}));

	it('should have dependencies defined', function () {
		expect(this.controller).toBeDefined();
	});

	it('should get the user on intialization', function () {
		this.scope.$apply();

		expect(this.UserService.Get).toHaveBeenCalled();
		expect(this.scope.OriginalEmail).toBe('xyz');
	});
});