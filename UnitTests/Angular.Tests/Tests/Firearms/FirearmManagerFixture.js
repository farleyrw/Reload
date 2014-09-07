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
		beforeEach(inject(function (_$httpBackend_, $rootScope, $controller, $location) {
			this.$httpBackend = _$httpBackend_;
			this.$httpBackend.expectGET('firearms/manage/list').respond([{ abc: '123' }]);
			this.$httpBackend.expectGET('/reload/firearms/enums').respond({ abc: '123' });

			this.scope = $rootScope.$new();
			this.controller = $controller('FirearmListController', { $scope: this.scope, $location: $location });
		}));

		it('should create scope methods', function () {
			expect(this.scope.Add).toBeDefined();
			expect(this.scope.Edit).toBeDefined();
			expect(this.scope.Delete).toBeDefined();
		});

		it('should create "Enums" model with data fetched from xhr', function () {
			this.$httpBackend.flush();

			expect(this.scope.Enums.abc).toBe('123');
		});

		it('should create "Firearms" model with data fetched from xhr', function () {
			this.$httpBackend.flush();

			expect(this.scope.Firearms[0].abc).toBe('123');
		});
	});
});