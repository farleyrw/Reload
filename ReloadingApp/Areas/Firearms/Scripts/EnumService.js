
FirearmManager.service("FirearmEnumService",
	["$http",
        function (ajax) {
		    return {
			    GetEnums: function () {
				    return ajax.get('Enums');
			    }
		    };
        }
	]
);