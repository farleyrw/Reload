
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

	/// Defines the namespace with the provided implementation with dependencies.
	Root.DefineNamespace = function (fullNamespace, implementation, dependencies) {
		fullNamespace = fullNamespace || "";

		var namespaceParts = fullNamespace.split(".");
		var parent = Root;

		if (namespaceParts[0] != Root.ModuleName) {
			throw "Namespace '" + fullNamespace + "' is not derived from " + Root.ModuleName;
		}

		// Construct the namespace.
		parent = namespaceParts.reduce(function (parent, current) {
			return parent[current] = parent[current] || {};
		}, window);

		// Set the definition to the specified implementation.
		if ($.isFunction(implementation)) { implementation.apply(parent, dependencies); }

		// Return the namespaced object with base functionality.
		return $.extend(true, parent, GetBaseObject(fullNamespace));
	};

	/// Returns if the namespace exists.
	function DoesNamespaceExist(namespace) {
		var highestDefinedModule = namespace.split('.').reduce(function (parent, current) {
			return parent[current] || parent;
		}, window);

		return highestDefinedModule.ModuleName == namespace;
	}

	/// Gets the base object to add to the 
	function GetBaseObject(fullNamespace) {
		return { ModuleName: fullNamespace };
	};
})(Reload, window, jQuery);