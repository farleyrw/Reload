
window.Reload = window.Reload || {};

(Reload = function (Root, window, $) {
	'use strict';

	window.Reload = Root;
	Root.ModuleName = "Reload";

	/// Adds the module if not already included.
	Root.IncludeModule = function (namespace) {
		if (!namespace || DoesNamespaceExist(namespace)) { return; }

		var moduleUrl = namespace.replace(/\./g, '/') + ".js";
		$('head').append('<script src="/reload/scripts/' + moduleUrl.toLowerCase() + '"></script>\n');
	};

	/// Adds the list of modules.
	Root.IncludeModules = function (namespaces) {
		namespaces.forEach(Root.IncludeModule);
	};

	/// Defines the namespace with the provided implementation with dependencies.
	Root.DefineNamespace = function (moduleNamespace, implementation, dependencies) {
		var namespaceParts = moduleNamespace.split(".");
		if (namespaceParts[0] != Root.ModuleName) {
			throw "Namespace '" + moduleNamespace + "' is not derived from " + Root.ModuleName;
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

	/// Gets the base object to add to the namespace.
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
})(Reload, window, jQuery);