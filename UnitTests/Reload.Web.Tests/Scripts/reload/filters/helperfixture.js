﻿
/// <reference path="/../../web/scripts/reload/filters/helpers.js" />

describe("Filter tests", function () {
	'use strict';

	// Create a module to test the filter.
	angular.module('FilterTestApp', [])
		.filter('EnumToString', Reload.Filters.Helpers.EnumToString);

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