
FirearmManager.service("FirearmListService",
	["$http", "$rootScope", "$resource",
        function (ajax, scope, xhr) {
		    var api = xhr('firearms/data/:action', {
				action: '@action'
		    }, {
		    	List: {
		    		method: 'GET',
					params: { action: 'list' },
		    		isArray: true
		    	},
		    	Delete: {
		    		method: 'POST',
		    		params: { action: 'delete' }
		    	}
		    });

		    return {
		    	Get: api.List,
				Query: api.List,
			    Delete: Delete,
			    Refresh: Refresh
		    };

		    function Get(callback) {
			    ajax.get('firearms/data/list').success(callback);
		    };

		    function Delete(firearmId) {
			    ajax.post('firearms/data/delete', { firearmId: firearmId }).success(Refresh);
		    };

		    function Refresh() {
			    scope.$broadcast('RefreshFirearmList');
		    };
        }
	]
);