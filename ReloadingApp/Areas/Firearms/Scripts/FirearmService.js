
FirearmManager.service("FirearmService",
	["$rootScope", "$resource",
		function (scope, ajax) {
			var api = ajax('firearms/data/:action/:id', {
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

			function GetFirearm(firearmId) {
				return api.Edit({ id: firearmId || 0 });
			};

			function SaveFirearm(firearm, callback) {
				api.Save({ firearm: firearm }, function () {
					Refresh();
					callback();
				});
			};

			function Delete(id) {
				api.Delete({ firearmId: id }, Refresh);
			};

			function Refresh() {
				scope.$broadcast('RefreshFirearmList');
			};

			return {
				List: api.List,
				Delete: Delete,
				Refresh: Refresh,
				Get: GetFirearm,
				Save: SaveFirearm
			};
		}
	]
);