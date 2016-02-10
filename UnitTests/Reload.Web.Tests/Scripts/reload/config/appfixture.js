/// <reference path="../../../../../web/scripts/reload/config/app.js" />

describe("app config module tests", function () {
	'use strict';

	var compileProvider, logProvider;

	beforeEach(function () {
		module(function ($compileProvider, $logProvider) {
			compileProvider = $compileProvider;
			logProvider = $logProvider;

			spyOn(compileProvider, 'debugInfoEnabled');
			spyOn(logProvider, 'debugEnabled');
		});
		module('reload.config.app');
	});

	beforeEach(inject(function () {
		this.compileProvider = compileProvider;
		this.logProvider = logProvider;
	}));

	it('should have dependencies defined', function () {
		expect(this.compileProvider).toBeDefined();
		expect(this.logProvider).toBeDefined();
	});

	it('should set configuration mode', function () {
		expect(this.compileProvider.debugInfoEnabled).toHaveBeenCalledWith(false);
		expect(this.logProvider.debugEnabled).toHaveBeenCalledWith(false);
	});
});