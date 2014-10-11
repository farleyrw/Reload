
(function (Root, window, $) {
	'use strict';

	Root.ModuleName = "Reload";

	/// Gets the url of the module.
	Root.GetModuleUrl = function (namespace) {
		var parts = namespace.split('.');

		parts.splice((parts.indexOf('Areas') == 1) ? 3 : 1, 0, 'Scripts', Root.ModuleName);

		return '/' + parts.join('/') + '.js';
	};

	/// Adds the module to the page if not already included.
	Root.IncludeModule = function (namespace) {
		if (!namespace || DoesNamespaceExist(namespace)) { return; }

		var moduleUrl = Root.GetModuleUrl(namespace);
		$('head').append('<script src="' + moduleUrl.toLowerCase() + '"></script>\n');
	};

	/// Adds the list of modules.
	Root.IncludeModules = function (namespaces) {
		namespaces.forEach(Root.IncludeModule);
	};

	/// Defines the namespace with the provided implementation with dependencies.
	Root.DefineNamespace = function (namespace, implementation, dependencies) {
		if (DoesNamespaceExist(namespace)) { return; }
		namespace = namespace || "";

		var namespaceParts = namespace.split(".");
		if (namespaceParts[0] != Root.ModuleName) {
			throw "Namespace '" + namespace + "' is not derived from " + Root.ModuleName;
		}

		// Construct the namespace.
		var module = namespaceParts.reduce(function (parent, current) {
			return parent[current] = parent[current] || {};
		}, window);

		// Set the definition to the specified implementation.
		if ($.isFunction(implementation)) { implementation.apply(module, dependencies); }

		// Return the namespaced object with base functionality.
		return $.extend(true, module, GetBaseObject(namespace));
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
