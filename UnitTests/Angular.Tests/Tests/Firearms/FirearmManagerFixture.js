/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-route.js" />
/// <reference path="../../../../web/scripts/angular/angular-resource.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/angular-ui/ui-bootstrap.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/angular/directives.js" />
/// <reference path="../../../../web/scripts/reload/angular/filters.js" />
/// <reference path="../../../../web/scripts/reload/angular/providers.js" />
/// <reference path="../../../../web/scripts/reload/angular/services.js" />
/// <reference path="../../../../web/areas/firearms/scripts/firearmservice.js" />
/// <reference path="../../../../web/areas/firearms/scripts/firearmmanager.js" />

describe('Firearm Manager tests', function () {
	beforeEach(module('FirearmManager'));

	describe('FirearmListController', function () {
		var scope, controller, $httpBackend;

		beforeEach(inject(function (_$httpBackend_, $rootScope, $controller, $location) {
			$httpBackend = _$httpBackend_;
			$httpBackend.expectGET('firearms/manage/list').respond([{ abc: '123' }]);
			$httpBackend.expectGET('/reload/firearms/enums').respond({ abc: '123' });

			scope = $rootScope.$new();
			controller = $controller('FirearmListController', { $scope: scope, $location: $location });
		}));

		it('should create scope methods', function () {
			expect(scope.Add).toBeDefined();
			expect(scope.Edit).toBeDefined();
			expect(scope.Delete).toBeDefined();
		});

		it('should create "Firearms" model with data fetched from xhr', function () {
			$httpBackend.flush();

			expect(scope.Firearms[0].abc).toBe('123');
		});

		it('should create "Enums" model with data fetched from xhr', function () {
			$httpBackend.flush();

			expect(scope.Enums.abc).toBe('123');
		});
	});
});