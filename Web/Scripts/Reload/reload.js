
(function (Reload, window, $) {
	'use strict';

	Reload.ModuleName = "Reload";

	/// Adds the module to the page if not already included.
	Reload.IncludeModule = function (namespace) {
		if (!namespace || DoesNamespaceExist(namespace)) { return; }

		var moduleUrl = namespace.replace(/\./g, '/') + ".js";
		$('head').append('<script src="/reload/scripts/' + moduleUrl.toLowerCase() + '"></script>\n');
	};

	/// Adds the list of modules.
	Reload.IncludeModules = function (namespaces) {
		namespaces.forEach(Reload.IncludeModule);
	};

	/// Defines the namespace with the provided implementation with dependencies.
	Reload.DefineNamespace = function (moduleNamespace, implementation, dependencies) {
		var namespaceParts = moduleNamespace.split(".");
		if (namespaceParts[0] != Reload.ModuleName) {
			throw "Namespace '" + moduleNamespace + "' is not derived from " + Reload.ModuleName;
		}

		// Construct the namespace.
		var namespace = namespaceParts.reduce(function (parent, current) {
			return parent[current] = parent[current] || {};
		}, window);

		// Set the definition to the specified implementation.
		if ($.isFunction(implementation)) { implementation.apply(namespace, dependencies); }

		// Return the namespaced object with base functionality.
		return $.extend(true, namespace, GetBaseObject(moduleNamespace));
	};

	/// Returns the base object of a namespace.
	function GetBaseObject(moduleNamespace) {
		return { ModuleName: moduleNamespace };
	};

	/// Returns if the namespace exists.
	function DoesNamespaceExist(namespace) {
		var highestDefinedModule = namespace.split('.').reduce(function (parent, current) {
			return parent[current] || parent;
		}, window);

		return highestDefinedModule.ModuleName == namespace;
	};
})(window.Reload = window.Reload || {}, window, jQuery);