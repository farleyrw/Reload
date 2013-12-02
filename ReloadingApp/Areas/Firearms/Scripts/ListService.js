
FirearmManager.service("FirearmListService",
	["$http", "$rootScope",
        function (ajax, scope) {
		    return {
			    Get: Get,
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