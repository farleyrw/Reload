'use strict';

Reload.DefineNamespace('Reload.Angular.Services', function () {
	this.Enums = function (ajax, resourceUrl) {
		var api = ajax(resourceUrl, {}, { Get: { method: 'GET', cache: true } });

		return { Get: api.Get };
	};
})