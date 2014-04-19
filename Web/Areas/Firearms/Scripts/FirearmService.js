'use strict';

FirearmManager.service("FirearmService",
	["$resource",
		function (ajax) {
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

			function Get(firearmId) {
				return api.Edit({ id: firearmId || 0 });
			};

			/*var Firearms = api.List();

			function GetNew(firearmId) {
				var firearm = {};
				Firearms.forEach(function(key) {
					if (key.FirearmId == firearmId) {
						firearm = key;
					}
				});
				return firearm;
			};*/

			function Save(firearm, callback) {
				api.Save({ firearm: firearm }, callback);
			};

			function Delete(firearm, callback) {
				api.Delete({ firearmId: firearm.FirearmId }, callback);
			};

			return {
				List: api.List,
				Delete: Delete,
				Get: Get,
				Save: Save
			};
		}
	]
);