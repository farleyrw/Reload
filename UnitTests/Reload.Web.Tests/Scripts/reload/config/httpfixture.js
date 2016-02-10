/// <reference path="../../../../../web/scripts/reload/config/http.js" />

describe("http config module tests", function () {
	'use strict';

	var httpProvider, paramSerializer;

	beforeEach(module('reload.config.http', function ($httpProvider, $httpParamSerializerJQLikeProvider) {
		httpProvider = $httpProvider;
		paramSerializer = $httpParamSerializerJQLikeProvider;
	}));

	beforeEach(inject(function () {
		this.httpProvider = httpProvider;
		this.paramSerializer = paramSerializer;
		this.transformRequest = httpProvider.defaults.transformRequest[0];
	}));

	it('should have dependencies defined', function () {
		expect(this.httpProvider).toBeDefined();
		expect(this.paramSerializer).toBeDefined();
		expect(this.transformRequest).toBeDefined();
	});

	it('should set post content-type defaults', function () {
		expect(this.httpProvider.defaults.headers.post['Content-Type']).toBe('application/x-www-form-urlencoded;charset=utf-8');
	});

	it('should set transform request to use jq serializer', function () {
		var testData = { test: 'value' };

		expect(this.transformRequest(testData)).toBe(this.paramSerializer.$get()(testData));
	});
});