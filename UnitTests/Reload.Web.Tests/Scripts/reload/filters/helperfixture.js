/// <reference path="../../../../../web/scripts/jquery/jquery-2.1.3.js" />

/// <reference path="../../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../../web/scripts/angular/angular-mocks.js" />

/// <reference path="../../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../../web/scripts/reload/filters/helpers.js" />

'use strict';

// Create a module to test the filter.
angular.module('FilterTestApp', [])
	.filter('EnumToString', Reload.Filters.Helpers.EnumToString);

describe("Filter tests", function () {

	beforeEach(function() {
		module('FilterTestApp');

		inject(function ($filter) {
			this.filter = $filter;
		});

		this.Enums = {
			Enum: [{ Id: 1, Name: 'Name'}]
		};
	});

	describe('EnumToString filter tests', function () {
		it('should have a EnumToString filter defined', function () {
			expect(this.filter('EnumToString')).toBeDefined();
		});

		it('should return the name given a valid index', function () {
			expect(this.filter('EnumToString')(0, this.Enums.Enum)).toEqual(this.Enums.Enum[0].Name);
		});

		it('should return the index given an invalid index', function () {
			expect(this.filter('EnumToString')(1, this.Enums.Enum)).toEqual(1);
		});
	});
});