/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/angular/providers.js" />
/// <reference path="../../../../web/scripts/modules/authorization.js" />

'use strict';

describe("Authorization provider test", function () {
	var httpProvider;
	beforeEach(function () {
		module('Authorization', function ($httpProvider) {
			httpProvider = $httpProvider;
		});

		inject(function (_AuthorizationService_) {
			this.AuthorizationService = _AuthorizationService_;
		});
	});

	var token = 'someToken';

	describe('Authorization Tests', function () {
		it('should have AuthorizationService be defined', function () {
			expect(this.AuthorizationService).toBeDefined();
			console.log(this.AuthorizationService);
		});

		describe('HTTP tests', function () {
			it('should have Authorization as an interceptor', function () {
				expect(httpProvider.interceptors).toContain('Authorization');
			});
			/*
			it('should token in the headers after setting', function () {
				RequestService.setToken(token);
				$httpBackend.when('GET', 'http://example.com', null, function (headers) {
					expect(headers.Authorization).toBe(token);
				}).respond(200, { name: 'example' });
			});

			it('should not place a token in the http request headers if no token is set', function () {
				var config = RequestService.request({ headers: {} });
				expect(config.headers['Authorization']).toBe(undefined);
			});

			it('should place a token in the http request headers after a token is set', function () {
				RequestService.setToken(token);
				var config = RequestService.request({ headers: {} });
				expect(config.headers['Authorization']).toBe('Token token="' + token + '"');
			});
			*/
		}); //Mocked HTTP Requests
	}); //RequestService tests
});