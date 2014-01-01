
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

		    function Delete(id) {
		    	api.Delete({ firearmId: id }, Refresh);
		    };

		    function Refresh() {
			    scope.$broadcast('RefreshFirearmList');
		    };

		    return {
		    	Get: api.List,
			    Delete: Delete,
			    Refresh: Refresh
		    };
        }
	]
);