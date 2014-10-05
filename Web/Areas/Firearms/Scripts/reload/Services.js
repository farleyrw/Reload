'use strict';

Reload.DefineNamespace('Reload.Areas.Firearms.Services', function () {
	/// The firearm web service.
	this.WebService = function (ajax) {
		var api = ajax('firearms/manage/:action/:id', {
			action: '@action',
			id: '@id'
		}, {
			List: {
				method: 'GET',
				params: { action: 'list' },
				isArray: true
			},
			Delete: {
				method: 'POST',
				params: { action: 'delete' }
			},
			Edit: {
				method: 'GET',
				params: { action: 'edit', id: 'id' }
			},
			Save: {
				method: 'POST',
				params: { action: 'save' }
			}
		});

		return {
			List: api.List,
			Delete: function (firearm, callback) {
				api.Delete({ firearmId: firearm.FirearmId }, callback);
			},
			Get: function (firearmId) {
				return firearmId ? api.Edit({ id: firearmId || 0 }) : {};
			},
			Save: function (firearm, callback) {
				api.Save({ firearm: firearm }, callback);
			}
		};
	};
});