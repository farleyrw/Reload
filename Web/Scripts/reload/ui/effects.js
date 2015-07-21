﻿
Reload.DefineNamespace('Reload.Ui.Effects', function () {
	'use strict';

	/// Directive that provides hover highlighting.
	this.HoverHighlight = function () {
		return {
			restrict: 'A',
			link: function (scope, element, attributes) {
				element.hover(
					function () { element.addClass('hoverHighlight'); },
					function () { element.removeClass('hoverHighlight'); }
				);
			}
		};
	};
});