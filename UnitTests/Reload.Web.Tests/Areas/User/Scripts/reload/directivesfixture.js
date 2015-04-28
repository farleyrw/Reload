
/// <reference path="/../../web/areas/user/scripts/reload/directives.js" />

'use strict';

// Create a module to test the directives.
describe('User area', function () {
	var app = angular.module('TestApp', []);

	describe('Compare to directive', function () {
		var form, element, scope;

		app.directive('compareTo', ['$parse', Reload.Areas.User.Directives.CompareTo]);

		beforeEach(module('TestApp'));

		beforeEach(inject(function ($compile, $rootScope) {
			scope = $rootScope;

			scope.stuff = {
				item1: 'value',
				item2: 'value',
				item3: 'value'
			};

			element = angular.element(
				'<form name="funform">' +
					'<input name="item1" ng-model="stuff.item1" />' +
					'<input name="item2" ng-model="stuff.item2" compare-to="stuff.item1" />' +
					'<input name="item3" ng-model="stuff.item3" compare-to="stuff.item2" negate="true" />' +
				'</form>'
			);

			$compile(element)(scope);
			scope.$digest();

			form = scope.funform;
		}));

		it('should have prerequisites defined', function () {
			expect(form).toBeDefined();
			expect(form.item1).toBeDefined();
			expect(form.item2).toBeDefined();
			expect(form.item1.$viewValue).toBe(scope.stuff.item1);
			expect(form.item2.$viewValue).toBe(scope.stuff.item2);
			expect(element).toBeDefined();
		});

		it('should validate when comparison values change', function () {
			expect(form.item2.$valid).toBe(true);
			form.item1.$setViewValue('1');
			expect(form.item2.$invalid).toBe(true);
		});

		it('should negate comparison with attribute set to true', function () {
			expect(form.item3.$invalid).toBe(true);
			form.item2.$setViewValue('1');
			expect(form.item3.$valid).toBe(true);
		});
	});

	describe('Unique email directive', function () {
		var form, element, scope, q;

		app
			.service('UserService', function () {
				return {
					ValidateEmail: function (email) {
						var deferred = q.defer();

						// Mock the result with an http get promise
						if (email.indexOf('taken') > -1) {
							deferred.resolve({ data: { Success: false, Message: 'Taken email' } });
						} else {
							deferred.resolve({ data: { Success: true, Message: '' } });
						}

						return deferred.promise;
					}
				};
			})
			.directive('uniqueEmail', ['$q', 'UserService', Reload.Areas.User.Directives.UniqueEmail]);

		beforeEach(module('TestApp'));

		beforeEach(inject(function ($compile, $rootScope, $q) {
			q = $q;
			scope = $rootScope;

			scope.stuff = {
				email: ''
			};

			element = angular.element(
				'<form name="funform">' +
					'<input name="email" ng-model="stuff.email" unique-email />' +
				'</form>'
			);

			$compile(element)(scope);
			scope.$digest();

			form = scope.funform;
		}));

		it('should have prerequisites defined', function () {
			expect(form).toBeDefined();
			expect(form.email).toBeDefined();
			expect(element).toBeDefined();
		});

		it('should validate email', function () {
			form.email.$setViewValue('test@email.com');
			scope.$digest();
			expect(form.email.$valid).toBe(true);
			expect(form.email.$error.emailAvailable).toBeUndefined();
			
			form.email.$setViewValue('taken@email.com');
			scope.$digest();
			expect(form.email.$invalid).toBe(true);
			expect(form.email.$error.emailAvailable).toBe(true);
		});
	});
});