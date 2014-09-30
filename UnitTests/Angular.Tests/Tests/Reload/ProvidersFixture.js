/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/angular/angular-resource.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/angular/providers.js" />
/// <reference path="../../../../web/scripts/modules/authorization.js" />

'use strict';

describe("Authorization provider test", function () {
	beforeEach(module('Authorization'));
	
	describe('Authorization Tests', function () {
		beforeEach(inject(function (_AuthorizationService_, $httpBackend) {
			this.httpBackend = $httpBackend;
			this.AuthorizationService = _AuthorizationService_;
		}));

		it('should have AuthorizationService be defined', function () {
			expect(this.AuthorizationService).toBeDefined();
		});

		it('should have AuthorizationService as an interceptor', function () {
			expect(this.httpBackend.interceptors).toContain('AuthorizationService');
		});
			
		it('should redirect on 401 response', function () {
			this.httpBackend.expectGet('http://localhost/reload').respond(401, null);
			this.httpBackend.flush();

			expect(browser().location().path()).toBe("/dashboard"); // TODO: get the login url.
		});
	});
});