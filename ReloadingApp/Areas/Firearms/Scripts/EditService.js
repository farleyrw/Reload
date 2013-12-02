
FirearmManager.service('FirearmEditService',
	['$http', 'FirearmListService',
        function (ajax, ListService) {
		    return {
			    Get: GetFirearm,
			    Save: SaveFirearm
		    };

		    function GetFirearm(firearmId, callback) {
			    ajax.get('firearms/data/edit/' + (firearmId || 0)).success(callback);
		    };

		    function SaveFirearm(firearm, callback) {
			    ajax.post('firearms/data/save', firearm).success(function () {
				    ListService.Refresh();
				    callback();
			    });
		    };
        }
	]
);