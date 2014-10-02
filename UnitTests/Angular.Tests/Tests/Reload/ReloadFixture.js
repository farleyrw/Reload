
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />
/// <reference path="../../../../web/scripts/reload/reload.js" />

'use strict';

describe("Reload module tests", function () {
	var Reload = window.Reload;
	it('should have Reload be defined', function () {
		expect(Reload).toBeDefined();
	});

	it('should have Reload initialized', function () {
		expect(Reload.ModuleName).toBe("Reload");
		expect(Reload.IncludeModule).toBeDefined();
		expect(Reload.IncludeModules).toBeDefined();
		expect(Reload.DefineNamespace).toBeDefined();
	});

	it('should create module url', function () {
		expect(Reload.GetModuleUrl('Reload.Test.Example')).toBe('/Reload/Scripts/Reload/Test/Example.js');
		expect(Reload.GetModuleUrl('Reload.Areas.AreaName.Test.Example')).toBe('/Reload/Areas/AreaName/Scripts/Reload/Test/Example.js');
	});

	it('should create namespaced module', function () {
		var module = Reload.DefineNamespace('Reload.Test', function () {
			this.Prop = 'lawl';
			this.Func = function () { return this.Prop; };
		});

		expect(module).toEqual(Reload.Test);
		expect(module.Prop).toBe('lawl');
		expect(module.Func()).toBe('lawl');
	});
});