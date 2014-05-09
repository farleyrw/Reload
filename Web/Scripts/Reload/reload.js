
if (typeof reload == "undefined") {
	'use strict';

	var reload = reload || {};

	(reload = function (Root, window) {
		window.reload = Root;

		/// Adds the module if not already included. This only works when hosted on a web server.
		Root.IncludeModule = function (moduleNamespace) {
			if (!moduleNamespace) { return; }

			if (typeof window[moduleNamespace] == "undefined") {
				var moduleUrl = moduleNamespace.replace(/\./g, '/') + ".js";
				console.log(moduleUrl);
				//$('head').append('<script src="/reload/scripts/' + moduleUrl.toLowerCase() + '"></script>\n');
			}
		};

	})(reload, window);
}

/// A module off of the parent namespace.
(reload.Module = reload.Module || function (Root) {
	// Create an alias to the full module namespace.
	var Module = Root.Module;

})(reload);