'use strict';

Informz.DefineNamespace('Informz.System.BaseModelHelper', function ($) {
	/// The model extender service.
	this.ModelExtender = function () {
		/// Extends the model implementation to include base functionality.
		this.Extend = function (model) {
			if (!model.hasOwnProperty('ModelState')) { return; }

			for (var property in model) {
				if (Object.prototype.toString.call(model[property]) === '[object Array]') {
					for (var arrayIndex = 0; arrayIndex < model[property].length; arrayIndex++) {
						this.Extend(model[property][arrayIndex]);
					}
				}
			}

			return $.extend(true, model, ModelExtensions);
		};

		/// The model state types.
		this.ModelStateTypes = {
			Added: 0,
			Deleted: 1,
			Detached: 2,
			Modified: 3,
			Unchanged: 4
		};

		/// Returns a new base model.
		this.GetBaseModel = function (model) {
			model.ModelState = this.ModelStateTypes.Added;

			return this.Extend(model);
		};

		// The base model extensions.
		var ModelExtensions = {
			ModelStateTypes: this.ModelStateTypes,
			IsRemoved: function () {
				return (this.ModelState == this.ModelStateTypes.Deleted || this.ModelState == this.ModelStateTypes.Detached);
			},
			Remove: function () {
				if (this.ModelState == this.ModelStateTypes.Added) {
					// If it was "Added" then change to detached.  We don't simply remove the object because that would
					// be inconsistent with how a saved object is removed and could cause unexpected behavior.
					this.ModelState = this.ModelStateTypes.Detached;
				} else if (this.ModelState != this.ModelStateTypes.Detached) { // If it is "Detached" there is no need to remove.
					this.ModelState = this.ModelStateTypes.Deleted;
				}
			},
			Restore: function () {
				if (this.ModelState == this.ModelStateTypes.Detached) {
					this.ModelState = this.ModelStateTypes.Added;
				} else {
					this.ModelState = this.ModelStateTypes.Unchanged;
				}
			}
		};
	};
}, [jQuery]);