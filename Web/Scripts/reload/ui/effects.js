
(function () {
	'use strict';

	angular.module('reload.ui.effects', [])
		.directive('hoverHighlight', function() {
			/// Directive that provides hover highlighting.
			return {
				restrict: 'A',
				link: function (scope, element, attributes) {
					element.hover(
						function () { element.addClass('hoverHighlight'); },
						function () { element.removeClass('hoverHighlight'); }
					);
				}
			};
		});
})();