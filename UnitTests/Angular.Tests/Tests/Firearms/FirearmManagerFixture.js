/// <reference path="../../../../web/scripts/jquery/jquery-2.1.3.js" />

/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-route.js" />
/// <reference path="../../../../web/scripts/angular/angular-resource.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/angular-ui/ui-bootstrap-tpls.js" />
/// <reference path="../../../../web/scripts/angular-ui/ui-bootstrap.js" />
/// <reference path="../../../../web/scripts/angular-block-ui/angular-block-ui.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/filters/helpers.js" />
/// <reference path="../../../../web/scripts/reload/providers/authorization.js" />
/// <reference path="../../../../web/scripts/reload/web/services.js" />
/// <reference path="../../../../web/scripts/reload/ui/controls.js" />
/// <reference path="../../../../web/scripts/reload/ui/effects.js" />
/// <reference path="../../../../web/scripts/reload/ui/widgets.js" />
/// <reference path="../../../../web/scripts/modules/authorization.js" />
/// <reference path="../../../../web/areas/firearms/scripts/reload/services.js" />
/// <reference path="../../../../web/areas/firearms/scripts/reload/controllers.js" />
/// <reference path="../../../../web/areas/firearms/scripts/firearmmanager.js" />

describe('Firearm Manager tests', function () {
	beforeEach(module('FirearmManager'));

	describe('FirearmListController', function () {
		beforeEach(inject(function ($httpBackend, $rootScope, $controller, $location) {
			this.httpBackend = $httpBackend;
			this.httpBackend.expectGET('firearms/manage/list').respond([{ abc: '123' }]);
			this.httpBackend.expectGET('/reload/firearms/enums/get').respond({ abc: '123' });

			this.scope = $rootScope.$new();
			this.controller = $controller('FirearmListController', { $scope: this.scope, $location: $location });
		}));

		it('should create scope methods', function () {
			expect(this.scope.Add).toBeDefined();
			expect(this.scope.Edit).toBeDefined();
			expect(this.scope.Delete).toBeDefined();
		});

		it('should create "Enums" model with data fetched from xhr', function () {
			this.httpBackend.flush();

			expect(this.scope.Enums.abc).toBe('123');
		});

		it('should create "Firearms" model with data fetched from xhr', function () {
			this.httpBackend.flush();

			expect(this.scope.Firearms[0].abc).toBe('123');
		});
	});
});