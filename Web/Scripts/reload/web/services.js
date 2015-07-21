
Reload.DefineNamespace('Reload.Web.Services', function () {
	'use strict';

	/// Provides a service that gets enums.
	this.Enums = function (ajax, resourceUrl) {
		var api = ajax(resourceUrl, {}, { Get: { method: 'GET', cache: true } });

		return { Get: api.Get };
	};
});