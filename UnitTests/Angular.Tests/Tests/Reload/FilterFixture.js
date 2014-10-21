/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/scripts/reload/filters/helpers.js" />

'use strict';

angular.module('FilterApp', [])
	.filter('Helper', Reload.Filters.Helpers.EnumToString);

describe("Filter tests", function () {
	beforeEach(module('FilterApp'));

	beforeEach(function () {
		this.Enums = {
			Enum: [{ Id: 1, Name: ''}]
		};
	});

	describe('Helper filter tests', function () {
		it('should have a range filter', inject(function ($filter) {
			expect($filter('Helper')).toBeDefined();
		}));
	});
});