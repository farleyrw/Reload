
Reload.DefineNamespace('Reload.Common.Example.TestModule', function ($) {
	'use strict';

	var x = "X";

	this.Do = function () {
		return x;
	};

	this.jqueer = $;
}, [jQuery]);