
Reload.DefineNamespace('Reload.Areas.User.Directives', function () {
    this.CompareTo = angular.noop;
    this.UniqueEmail = angular.noop;
});

Reload.DefineNamespace('Reload.Areas.User.Services', function () {
    this.UserService = function () {
        return {
            Get: jasmine.createSpy('Get'),
            SaveUser: jasmine.createSpy('SaveUser')
        };
    };
    this.PasswordChangeDialogService = angular.noop;
});