
(function (Root, window, $) {
	'use strict';

	Root.ModuleName = 'Reload';

	/// Adds the module to the page if not already included.
	Root.UsingModule = function (namespace) {
		if (!namespace || !ParseNamespace(namespace)) {
			throw 'Namespace dependency "' + namespace + '" does not exist.';
		}
	};

	/// Adds the list of modules.
	Root.UsingModules = function (namespaces) {
		namespaces.forEach(Root.UsingModule);
	};

	/// Defines the namespace with the provided implementation with dependencies.
	Root.DefineNamespace = function (namespace, implementation, dependencies) {
		var module = ParseNamespace(namespace);

		if (!module) {
			namespace = namespace || '';

			var namespaceParts = namespace.split('.');
			if (namespaceParts[0] != Root.ModuleName) {
				throw 'Namespace "' + namespace + '" is not derived from ' + Root.ModuleName;
			}

			// Construct the namespace.
			var module = namespaceParts.reduce(function (parent, current) {
				return parent[current] = parent[current] || {};
			}, window);
		}

		// Set the definition to the specified implementation.
		if ($.isFunction(implementation)) { implementation.apply(module, dependencies); }

		// Return the namespaced object with base functionality.
		return $.extend(true, module, GetBaseObject(namespace));
	};

	/// Returns the base object of a namespace.
	function GetBaseObject(moduleNamespace) {
		return { ModuleName: moduleNamespace };
	}

	/// Parses the string namespace to an object.
	function ParseNamespace(namespace) {
		return namespace.split('.').reduce(function (parent, current) {
			return parent[current];
		}, window);
	}
})(window.Reload = window.Reload || {}, window, jQuery);