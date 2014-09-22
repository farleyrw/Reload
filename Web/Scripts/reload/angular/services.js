'use strict';

Reload.DefineNamespace('Reload.Angular.Services', function () {
	// Provides a service that gets enums.
	this.Enums = function (ajax, resourceUrl) {
		var api = ajax(resourceUrl, {}, { Get: { method: 'GET', cache: true } });

		return { Get: api.Get };
	};

	// Provides a confirmation dialog.
	this.ConfirmDialog = function (modal) {
		return {
			Show: function (name) {
				return modal.open({
					size: 'sm',
					controller: function ($scope, $modalInstance) {
						$scope.Name = name;

						$scope.Confirm = $modalInstance.close;

						$scope.Cancel = $modalInstance.dismiss;
					},
					template:
						'<div class="modal-header"><h3 class="modal-title">Confirm</h3></div>' +
						'<div class="modal-body">Are you sure you want to delete your {{ Name }}?</div>' +
						'<div class="modal-footer">' +
							'<button class="btn btn-primary" ng-click="Confirm()">OK</button>' +
							'<button class="btn btn-warning" ng-click="Cancel()">Cancel</button>' +
						'</div>'
				}).result;
			}
		};
	};
});