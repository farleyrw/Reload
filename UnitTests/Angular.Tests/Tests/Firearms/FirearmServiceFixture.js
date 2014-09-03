/// <reference path="../../../../web/scripts/angular/angular.js" />
/// <reference path="../../../../web/scripts/angular/angular-resource.js" />
/// <reference path="../../../../web/scripts/angular/angular-mocks.js" />
/// <reference path="../../../../web/scripts/jquery/jquery-2.1.1.js" />

/// <reference path="../../../../web/scripts/reload/reload.js" />
/// <reference path="../../../../web/areas/firearms/scripts/firearmservice.js" />


describe('Firearm Service', function () {
	var mockFirearmService, $httpBackend;

	beforeEach(function () {
		var injector = angular.injector(['ngResource']);
		angular.mock.inject(function ($injector) {

			$httpBackend = $injector.get('$httpBackend');
			var resource = injector.get('$resource');
			mockFirearmService = Reload.Firearms.Service.FirearmService(resource);
			console.log(mockFirearmService);
		});
	});

	it('should get list', inject(function ($httpBackend) {

		$httpBackend.expectGET('firearms/manage/list').respond([]);

		var result = mockFirearmService.List();

		$httpBackend.flush();

		expect(result).toEqualData([]);
	}));
});