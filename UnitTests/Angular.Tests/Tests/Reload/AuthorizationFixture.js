/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/providers/authorization.js" />
/// <reference path="../../../../web/scripts/modules/authorization.js" />

'use strict';

describe("Authorization module tests", function () {
	var httpProvider;
	var exampleUrl = '/reload';

	beforeEach(module('Authorization', function ($httpProvider) {
		httpProvider = $httpProvider;
	}));

	beforeEach(inject(function ($httpBackend, _AuthorizationService_, $window) {
		this.httpBackend = $httpBackend;
		this.AuthorizationService = _AuthorizationService_;

		this.window = $window;
		this.window.alert = jasmine.createSpy();
		this.window.location = {
			reload: jasmine.createSpy()
		};
	}));

	describe('Authorization service tests', function () {
		it('should have AuthorizationService be defined', function () {
			expect(this.AuthorizationService).toBeDefined();
		});

		it('should have AuthorizationService as an interceptor', function () {
			expect(httpProvider.interceptors).toContain('AuthorizationService');
		});
			
		it('should redirect on 401 response', function (done) {
			this.httpBackend.expectGET(exampleUrl).respond(401, null);

			this.httpBackend.flush();
			expect(this.window.alert).toHaveBeenCalled();
		});

		/*it('should pass through a 200 response', function (done) {
			this.httpBackend.when('GET', exampleUrl, null, function () {
				expect(this.window.location.reload).toHaveBeenCalled();
				done();
			}).respond(200, null);
		});*/
	});
});