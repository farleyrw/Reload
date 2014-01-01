
FirearmManager.service('FirearmEditService',
	['$resource', 'FirearmListService',
        function (ajax, ListService) {
        	var api = ajax('firearms/data/:action/:id', {
        		action: '@action',
				id: '@id'
        	}, {
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
				    ListService.Refresh();
				    callback();
			    });
		    };

		    return {
			    Get: GetFirearm,
			    Save: SaveFirearm
		    };
        }
	]
);