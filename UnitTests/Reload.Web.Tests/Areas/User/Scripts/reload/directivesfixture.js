/// <reference path="../../../../../../web/scripts/jquery/jquery-2.1.3.js" />

/// <reference path="../../../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../../../web/scripts/angular/angular-mocks.js" />

/// <reference path="../../../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../../../web/areas/user/scripts/reload/directives.js" />

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

		xit('should have prerequisites defined', function () {
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
		var form, element, scope;

		app
			.service('UserService', function () {
				return {
					ValidateEmail: function (email) {
						// TODO: mock this result with a promise
					}
				};
			})
			.directive('uniqueEmail', ['$q', 'UserService', Reload.Areas.User.Directives.UniqueEmail]);

		beforeEach(module('TestApp'));

		beforeEach(inject(function ($rootScope) {
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

		xit('should have prerequisites defined', function () {
			expect(form).toBeDefined();
			expect(form.email).toBeDefined();
			expect(element).toBeDefined();
		});
	});
});