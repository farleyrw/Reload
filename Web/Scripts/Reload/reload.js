
window.Reload = window.Reload || {};

(Reload = function (Root, window, $) {
	'use strict';

	window.Reload = Root;
	Root.ModuleName = "Reload";

	/// Adds the module if not already included.
	Root.IncludeModule = function (moduleNamespace) {
		if (!moduleNamespace) { return; }

		if (typeof window[moduleNamespace] == "undefined") {
			var moduleUrl = moduleNamespace.replace(/\./g, '/') + ".js";
			console.log(moduleUrl);
			//$('head').append('<script src="/reload/scripts/' + moduleUrl.toLowerCase() + '"></script>\n');
		}
	};

	/// Defines the namespace with the provided implementation.
	Root.DefineNamespace = function (fullNamespace, implementation) {
		fullNamespace = fullNamespace || "";

		var namespaceParts = fullNamespace.split(".");
		var parent = Root;

		if (namespaceParts[0] != Root.ModuleName) {
			throw "Namespace '" + fullNamespace + "' is not built from " + Root.ModuleName;
		}

		// Remove root namespace.
		namespaceParts = namespaceParts.slice(1);

		// Loop through namespace parts and create a nested namespaces.
		for (var i = 0; i < namespaceParts.length; i++) {
			var namespacePart = namespaceParts[i];

			// Create the parent namespace if needed.
			if (typeof parent[namespacePart] === "undefined") {
				parent[namespacePart] = {};
			}

			parent = parent[namespacePart];
		}

		// Set the definition to the specified implementation.
		if ($.isFunction(implementation)) { implementation.call(parent); }

		// Return the namespaced object with base functionality.
		return $.extend(true, parent, GetBaseObject(fullNamespace));
	};

	function GetBaseObject(fullNamespace) {
		return { ModuleName: fullNamespace };
	};
})(Reload, window, jQuery);
