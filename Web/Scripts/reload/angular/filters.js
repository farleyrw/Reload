
Reload.DefineNamespace('Reload.Angular.Filters', function () {
	this.EnumToString = function () {
		return function (index, array) {
			return array ? array[index].Name : index;
		};
	};
});