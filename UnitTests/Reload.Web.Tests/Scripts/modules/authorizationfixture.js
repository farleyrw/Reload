
/// <reference path="../../../../web/scripts/reload/providers/authorization.js" />
/// <reference path="../../../../web/scripts/modules/authorization.js" />

'use strict';

describe("Authorization module tests", function () {
	var httpProvider;
	var window = {
		alert: jasmine.createSpy(),
		location: {
			reload: jasmine.createSpy()
		}
	};
	var exampleUrl = '/reload';

	beforeEach(module('Authorization', function ($httpProvider, $provide) {
		httpProvider = $httpProvider;
		// Provide window mock, angular doesn't allow you to mock this easily.
		$provide.value('$window', window);
	}));

	beforeEach(inject(function ($httpBackend, AuthorizationService, $http) {
		this.httpBackend = $httpBackend;
		this.AuthorizationService = AuthorizationService;
		this.http = $http;
	}));

	describe('Authorization service tests', function () {
		it('should have AuthorizationService as an interceptor', function () {
			expect(httpProvider.interceptors).toContain('AuthorizationService');
		});

		it('should have xml http header set', function () {
			expect(httpProvider.defaults.headers.common["X-Requested-With"]).toEqual('XMLHttpRequest');
		});

		it('should have AuthorizationService be defined', function () {
			expect(this.AuthorizationService).toBeDefined();
		});

		it('should pass through a 200 response', function () {
			this.httpBackend.expectGET(exampleUrl).respond(200);
			this.http.get(exampleUrl);

			this.httpBackend.flush();

			expect(window.alert).not.toHaveBeenCalled();
			expect(window.location.reload).not.toHaveBeenCalled();
		});

		it('should alert and reload on 401 response', function () {
			this.httpBackend.expectGET(exampleUrl).respond(401);
			this.http.get(exampleUrl);

			this.httpBackend.flush();

			expect(window.alert).toHaveBeenCalled();
			expect(window.location.reload).toHaveBeenCalled();
		});
	});
});