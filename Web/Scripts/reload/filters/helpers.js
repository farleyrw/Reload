'use strict';

Reload.DefineNamespace('Reload.Filters.Helpers', function () {
	/// Coverts the index of an enum to a string.
	this.EnumToString = function () {
		return function (index, array) {
			return (array instanceof Array && array[index]) ? array[index].Name : index;
		};
	};
});