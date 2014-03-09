'use strict';

FirearmManager.service("FirearmEnumService",
	["$resource",
        function (ajax) {
        	var api = ajax('firearms/enums', {}, { Get: { method: 'GET', cache: true } });

		    return { Get: api.Get };
        }
	]
);