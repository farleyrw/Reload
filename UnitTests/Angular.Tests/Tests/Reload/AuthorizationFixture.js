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

	beforeEach(inject(function ($httpBackend, AuthorizationService, $window) {
		this.httpBackend = $httpBackend;
		this.AuthorizationService = AuthorizationService;

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
		
		it('should pass through a 200 response', function () {
			this.httpBackend.whenGET(exampleUrl, null, function () {
				expect(this.window.alert).not.toHaveBeenCalled();
				expect(this.window.location.reload).not.toHaveBeenCalled();
			}).respond(200, null);
		});

		it('should redirect on 401 response', function () {
			this.httpBackend.whenGET(exampleUrl, null, function (headers) {
				expect(this.window.alert).toHaveBeenCalled();
				expect(this.window.location.reload).toHaveBeenCalled();
			}).respond(401, null);
		});
	});
});