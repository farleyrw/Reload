
FirearmManager.service("FirearmEnumService",
	["$resource",
        function (ajax) {
        	var api = ajax('firearms/enums', { }, {
        		Get: {
        			method: 'GET'
        		}
        	});

		    return {
			    Get: api.Get
		    };
        }
	]
);