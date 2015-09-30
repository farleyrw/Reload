
describe("Reload module tests", function () {
	'use strict';

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
		var shouldBeHerePhrase = 'I am here';

		Reload.DefineNamespace('Reload.Test', function () {
			this.ShouldBeHere = shouldBeHerePhrase;
		});

		expect(Reload.Test.ShouldBeHere).toBe(shouldBeHerePhrase);

		var shouldAlsoBeHerePhrase = 'I am also here';

		Reload.DefineNamespace('Reload.Test', function () {
			this.ShouldAlsoBeHere = shouldAlsoBeHerePhrase;
		});

		expect(Reload.Test.ShouldBeHere).toBe(shouldBeHerePhrase);
		expect(Reload.Test.ShouldAlsoBeHere).toBe(shouldAlsoBeHerePhrase);
	});
});