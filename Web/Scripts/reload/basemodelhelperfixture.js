
/// <reference path="../../../../../web/App/scripts/jquery/jquery-2.1.3.js" />
/// <reference path="../../../../../web/App/scripts/informz/informz.js" />
/// <reference path="../../../../../web/App/scripts/informz/system/basemodelhelper.js" />

'use strict';

describe("Base Model Helper module tests", function () {
	var BaseModelHelper = Informz.System.BaseModelHelper;
	var ModelExtender = new BaseModelHelper.ModelExtender();

	it('should have BaseModelHelper defined', function () {
		expect(BaseModelHelper).toBeDefined();
		expect(ModelExtender).toBeDefined();
	});

	it('should extend model with base functionality', function () {
		var model = ModelExtender.GetBaseModel({ prop: 'A' });
		
		expect(model.prop).toBe('A');
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Added);
		expect(model.ModelStateTypes).toBeDefined();
		expect(model.IsRemoved).toBeDefined();
		expect(model.Remove).toBeDefined();
		expect(model.Restore).toBeDefined();
		expect(model.IsRemoved()).toBe(false);
	});

	it('should read removed state correctly', function () {
		var model = ModelExtender.GetBaseModel({});

		model.ModelState = ModelExtender.ModelStateTypes.Deleted;
		expect(model.IsRemoved()).toBe(true);

		model.ModelState = ModelExtender.ModelStateTypes.Detached;
		expect(model.IsRemoved()).toBe(true);
	});

	it('should set removed state correctly', function () {
		var model = ModelExtender.GetBaseModel({});

		model.Remove();
		expect(model.IsRemoved()).toBe(true);

		model.ModelState = ModelExtender.ModelStateTypes.Added;
		model.Remove();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Detached);

		model.ModelState = ModelExtender.ModelStateTypes.Detached;
		model.Remove();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Detached);

		// Calling remove on any other state becomes deleted.
		model.ModelState = ModelExtender.ModelStateTypes.Deleted;
		model.Remove();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Deleted);

		model.ModelState = ModelExtender.ModelStateTypes.Modified;
		model.Remove();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Deleted);

		model.ModelState = ModelExtender.ModelStateTypes.Unchanged;
		model.Remove();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Deleted);
	});

	it('should set restore state correctly', function () {
		var model = ModelExtender.GetBaseModel({});

		model.ModelState = ModelExtender.ModelStateTypes.Detached;
		model.Restore();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Added);

		// Calling restore on any other state becomes unchanged.
		model.ModelState = ModelExtender.ModelStateTypes.Added;
		model.Restore();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Unchanged);

		model.ModelState = ModelExtender.ModelStateTypes.Deleted;
		model.Restore();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Unchanged);

		model.ModelState = ModelExtender.ModelStateTypes.Modified;
		model.Restore();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Unchanged);

		model.ModelState = ModelExtender.ModelStateTypes.Unchanged;
		model.Restore();
		expect(model.ModelState).toBe(ModelExtender.ModelStateTypes.Unchanged);
	});
});