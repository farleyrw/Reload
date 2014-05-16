
window.Reload = window.Reload || {};

(Reload = function (Root, window, $) {
	//'use strict';

	window.Reload = Root;
	Root.ModuleName = "Reload";

	/// Adds the module if not already included.
	Root.IncludeModule = function (namespace) {
		if (!namespace || typeof DoesNamespaceExist(namespace) != "undefined") { return; }

		var moduleUrl = namespace.replace(/\./g, '/') + ".js";
		$('head').append('<script src="/reload/scripts/' + moduleUrl.toLowerCase() + '"></script>\n');
	};

	/// Defines the namespace with the provided implementation with dependencies.
	Root.DefineNamespace = function (fullNamespace, implementation, dependencies) {
		fullNamespace = fullNamespace || "";

		var namespaceParts = fullNamespace.split(".");
		var parent = Root;

		if (namespaceParts[0] != Root.ModuleName) {
			throw "Namespace '" + fullNamespace + "' is not derived from " + Root.ModuleName;
		}

		// Remove root namespace.
		namespaceParts = namespaceParts.slice(1);
		
		// Loop through namespace parts and create a nested namespaces.
		for (var i = 0; i < namespaceParts.length; i++) {
			var namespacePart = namespaceParts[i];

			parent[namespacePart] = parent[namespacePart] || {};

			parent = parent[namespacePart];
		}

		/*parent = namespaceParts.reduce(function (parent, current) {
			return parent[current] = parent[current] || {};
		}, window);*/

		// Set the definition to the specified implementation.
		if ($.isFunction(implementation)) { implementation.apply(parent, dependencies); }

		// Return the namespaced object with base functionality.
		return $.extend(true, parent, GetBaseObject(fullNamespace));
	};

	/// Returns (safely) if the namespace exists.
	function DoesNamespaceExist(namespace) {
		return namespace.split('.').reduce(function (parent, current) {
			return (typeof parent == "undefined") ? parent : parent[current];
		}, window);
	}

	/// Gets the base object to add to the 
	function GetBaseObject(fullNamespace) {
		return { ModuleName: fullNamespace };
	};
})(Reload, window, jQuery);