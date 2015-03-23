'use strict';

Reload.DefineNamespace('Reload.Areas.User.Directives', function () {
	/// Validates a unique email address as an async model validator.
	this.UniqueEmail = function (promise, UserService) {
		return {
			restrict: 'A',
			require: 'ngModel',
			link: function (scope, element, attributes, ngModel) {
				ngModel.$asyncValidators.emailAvailable = function (modelValue, viewValue) {
					// TODO: fix OriginalEmail parent scope dependency.
					if (!modelValue || scope.OriginalEmail == modelValue) {
						return promise.when();
					}

					return UserService.ValidateEmail(modelValue).then(function (response) {
						if (!response.data.Success) {
							ngModel.emailValidationErrorMessage = response.data.Message;
							return promise.reject(response.data.Message);
						}

						return true;
					});
				};
			}
		};
	};

	/// Compares an element to another element as a model validator.
	this.CompareTo = function ($parse) {
		return {
			restrict: 'A',
			require: 'ngModel',
			link: function (scope, element, attributes, ngModel) {
				var compare = $parse(attributes.compareTo);

				ngModel.$validators.compareTo = function (modelValue) {
					var compareValue = compare(scope);

					if (typeof compareValue == 'undefined' || typeof modelValue == 'undefined') {
						return true;
					}

					if (attributes.negate === 'true') {
						return modelValue != compareValue;
					} else {
						return modelValue == compareValue;
					}
				};

				scope.$watch(
					function () { return compare(scope); },
					function () { ngModel.$validate(); }
				);
			}
		};
	};
});