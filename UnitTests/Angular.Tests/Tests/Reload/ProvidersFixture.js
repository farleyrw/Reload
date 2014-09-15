/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/angular/providers.js" />

'use strict';

describe("Angular provider test", function () {
	beforeEach(function () {
		module('services', function ($httpProvider) {
			//save our interceptor
			httpProviderIt = $httpProvider;
		});

		inject(function (_AuthService_, _RequestService_) {
			RequestService = _RequestService_;
			AuthService = _AuthService_;
		})
	});

	var RequestService, AuthService;
	var $httpBackend;
	var token = 'someToken';

	describe('RequestService Tests', function () {
		it('should have RequestService be defined', function () {
			expect(RequestService).toBeDefined();
		});

		it('should properly set an api token', function () {
			expect(RequestService.getToken()).toBeNull();
			RequestService.setToken(token);
			expect(RequestService.getToken()).toBe(token);
		});

		it('should save the users api token after saveUser', function () {
			spyOn(RequestService, 'setToken');
			Auth.saveUser(apiResponse);
			expect(RequestService.setToken).toHaveBeenCalled();
		});

		it('should have no api token upon start up', function () {
			var token = RequestService.getToken();
			expect(token).toBeNull();
		});

		describe('HTTP tests', function () {
			it('should have the RequestService as an interceptor', function () {
				expect(httpProviderIt.interceptors).toContain('RequestService');
			});

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
		}); //Mocked HTTP Requests
	}); //RequestService tests
});