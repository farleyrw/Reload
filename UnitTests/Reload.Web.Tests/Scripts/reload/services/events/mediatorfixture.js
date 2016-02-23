/// <reference path="../../../../../../web/scripts/reload/services/events/mediator.js" />

describe("Reload mediator tests", function () {
	'use strict';

	beforeEach(function () {
		this.service = Reload.Services.Events.Mediator;
	});

	it('should have dependencies defined', function () {
		expect(this.service).toBeDefined();
		expect(this.service.Listen).toBeDefined();
		expect(this.service.Fire).toBeDefined();
	});

	it('should register and fire callback', function () {
		var tested = false;

		this.service.Listen('x', function (response) {
			tested = response;
		});

		this.service.Fire('x', true);

		expect(tested).toBe(true);
	});
});