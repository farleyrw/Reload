
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
		var namespaceParts = fullNamespace.split(".");
		if (namespaceParts[0] != Root.ModuleName) {
			throw "Namespace '" + fullNamespace + "' is not derived from " + Root.ModuleName;
		}

		// Construct the namespace.
		var namespace = namespaceParts.reduce(function (parent, current) {
			return parent[current] = parent[current] || {};
		}, window);

		// Set the definition to the specified implementation.
		if ($.isFunction(implementation)) { implementation.apply(namespace, dependencies); }

		// Return the namespaced object with base functionality.
		return $.extend(true, namespace, GetBaseObject(fullNamespace));
	};

	/// Gets the base object to add to the 
	function GetBaseObject(fullNamespace) {
		return { ModuleName: fullNamespace };
	};

	/// Returns if the namespace exists.
	function DoesNamespaceExist(namespace) {
		var highestDefinedModule = namespace.split('.').reduce(function (parent, current) {
			return parent[current] || parent;
		}, window);

		return highestDefinedModule.ModuleName == namespace;
	};
})(Reload, window, jQuery);