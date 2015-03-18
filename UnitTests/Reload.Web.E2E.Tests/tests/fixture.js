describe('Idk wtf', function () {
	it('is going on', function () {
		browser.ignoreSynchronization = true
		browser.get('http://localhost/reload');
		
		expect(browser.getCurrentUrl()).toMatch('Account/Login');
		
		element(by.id('Email')).sendKeys('farleyrw@gmail.com');
		element(by.id('Password')).sendKeys('123456');
		
		element(by.buttonText('Login')).click();
		
		//browser.driver.sleep(3000);
		element(by.linkText('Account')).click();
		//browser.driver.sleep(3000);
		expect(browser.getCurrentUrl()).toMatch('User');
	});
});