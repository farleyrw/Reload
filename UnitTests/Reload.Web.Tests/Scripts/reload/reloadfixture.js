
describe("Reload module tests", function () {
	'use strict';

	var Reload = window.Reload;
	var testNamespace = 'Reload.Test.Namespace';

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
		var property = 'lawl';
		var module = Reload.DefineNamespace(testNamespace, function () {
			this.Prop = property;
			this.Func = function () { return this.Prop; };
		});

		expect(module).toEqual(Reload.Test.Namespace);
		expect(module.Prop).toBe(property);
		expect(module.Func()).toBe(property);
	});

	it('should throw if namespace is not derived from root namespace', function () {
		var badNamespace = 'Wrong.Thing';
		expect(function () { Reload.DefineNamespace(badNamespace); })
			.toThrow('Namespace "' + badNamespace + '" is not derived from Reload');
	});

	it('should throw if namespace dependency not defined', function () {
		expect(function () { Reload.UsingModule(''); }).toThrow();

		expect(function () { Reload.UsingModule('Reload.DNE'); }).toThrow();
	});

	it('should not throw if namespace dependencies are defined', function () {
		Reload.DefineNamespace(testNamespace, function () { });

		expect(function () {
			Reload.UsingModules([testNamespace, testNamespace]);
		}).not.toThrow();
	});

	it('should not throw if namespace dependency defined', function () {
		Reload.DefineNamespace(testNamespace, function () { });

		expect(function () { Reload.UsingModule(testNamespace); }).not.toThrow();
	});

	it('should not overwrite module', function () {
		var shouldBeHerePhrase = 'I am here';

		Reload.DefineNamespace(testNamespace, function () {
			this.ShouldBeHere = shouldBeHerePhrase;
		});

		expect(Reload.Test.Namespace.ShouldBeHere).toBe(shouldBeHerePhrase);

		var shouldAlsoBeHerePhrase = 'I am also here';

		Reload.DefineNamespace(testNamespace, function () {
			this.ShouldAlsoBeHere = shouldAlsoBeHerePhrase;
		});

		expect(Reload.Test.Namespace.ShouldAlsoBeHere).toBe(shouldAlsoBeHerePhrase);
		expect(Reload.Test.Namespace.ShouldBeHere).toBe(shouldBeHerePhrase);
	});
});