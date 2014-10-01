/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/angular/providers.js" />
/// <reference path="../../../../web/scripts/modules/authorization.js" />

'use strict';

describe("Authorization module tests", function () {
	var httpProvider;
	var testLoginUrl = '/logon';
	var exampleUrl = 'http://localhost/reload';

	beforeEach(module('Authorization', function ($httpProvider, $provide) {
		httpProvider = $httpProvider;
		$provide.constant("LoginUrl", testLoginUrl);
	}));

	beforeEach(inject(function ($httpBackend, _LoginUrl_, _AuthorizationService_) {
		this.httpBackend = $httpBackend;
		this.LoginUrl = _LoginUrl_;
		this.AuthorizationService = _AuthorizationService_;
	}));

	describe('Authorization service tests', function () {
		it('should have AuthorizationService be defined', function () {
			expect(this.AuthorizationService).toBeDefined();
		});

		it('should have LoginUrl set correctly', function () {
			expect(this.LoginUrl).toBe(testLoginUrl);
		});

		it('should have AuthorizationService as an interceptor', function () {
			expect(httpProvider.interceptors).toContain('AuthorizationService');
		});
			
		it('should redirect on 401 response', function () {
			this.httpBackend.when('GET', exampleUrl, null, function () {
				expect(browser().location().path()).toBe(testLoginUrl);
			}).respond(401, null);
		});

		it('should pass through a 200 response', function () {
			this.httpBackend.when('GET', exampleUrl, null, function () {
				expect(browser().location().path()).toBe(exampleUrl);
			}).respond(200, null);
		})
	});
});