/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/filters/helpers.js" />

'use strict';

describe("Filter tests", function () {
	
	beforeEach(module('', function () {
	}));

	beforeEach(inject(function () {

	}));

	describe('Helper filter tests', function () {
		it('should have Filter to be defined', function () {
			expect(this.AuthorizationService).toBeDefined();
		});
	});
});