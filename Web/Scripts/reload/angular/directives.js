'use strict';

Reload.DefineNamespace('Reload.Angular.Directives', function () {
	// Directive for modifying or deleting an item.
	this.ModifyItem = function () {
		return {
			restrict: 'E',
			replace: true,
			scope: {
				editClick: '&',
				deleteClick: '&'
			},
			template:
				'<span>' +
					'<button ng-click="editClick()" title="Edit" class="btn btn-primary">' +
						'<span class="glyphicon glyphicon-cog"></span> Edit' +
					'</button> ' +
					'<button ng-click="deleteClick()" title="Delete" class="btn btn-danger">' +
						'<span class="glyphicon glyphicon-trash"></span> Delete' +
					'</button>' +
				'</span>'
		};
	};
});