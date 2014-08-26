'use strict';

Reload.DefineNamespace('Reload.Angular.Filters', function () {
	// Coverts an enum to a string.
	this.EnumToString = function () {
		return function (index, array) {
			return (array instanceof Array) ? array[index].Name : index;
		};
	};
});