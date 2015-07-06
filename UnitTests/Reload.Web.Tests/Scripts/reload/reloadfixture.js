
'use strict';

describe("Reload module tests", function () {
	var Reload = window.Reload;

	beforeEach(function () {
		// Reset test namespace.
		delete Reload.Test;
	});

	it('should have Reload be defined', function () {
		expect(Reload).toBeDefined();
	});

	it('should have Reload initialized', function () {
		expect(Reload.ModuleName).toBe("Reload");
		expect(Reload.UsingModule).toBeDefined();
		expect(Reload.UsingModules).toBeDefined();
		expect(Reload.DefineNamespace).toBeDefined();
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

	it('should throw if namespace dependency not defined', function () {
		expect(function () { Reload.UsingModule(''); }).toThrow();

		expect(function () { Reload.UsingModule('Reload.DNE'); }).toThrow();
	});

	it('should not throw if namespace dependency defined', function () {
		Reload.DefineNamespace('Reload.Test', function () { });

		expect(function () { Reload.UsingModule('Reload.Test'); }).not.toThrow();
	});

	it('should not overwrite module', function () {
		Reload.DefineNamespace('Reload.Test', function () {
			this.ShouldBeHere = 'I am here';
		});

		expect(Reload.Test.ShouldBeHere).toBe('I am here');

		Reload.DefineNamespace('Reload.Test', function () {
			this.ShouldNotBeHere = 'I am not here';
		});

		expect(Reload.Test.ShouldNotBeHere).toBeUndefined();
	});

	// TODO: create tests for the remaining methods in the module.

	/*it('should include module', function () {
		// To test this we must fake out the GetModuleUrl() function.
		Reload.GetModuleUrl = function () { return '/reload/test.js'; }
		
		Reload.UsingModule('Reload.Test');

		expect($('head script[src="/reload/test.js"]')).toBeDefined();
		//expect(document.getElementsByTagName('script')[0].href).toBe('');
	});*/
});