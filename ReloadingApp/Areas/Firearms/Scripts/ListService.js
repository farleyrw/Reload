
FirearmManager.service("FirearmListService",
	["$rootScope", "$resource",
        function (scope, ajax) {
		    var api = ajax('firearms/data/:action', {
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