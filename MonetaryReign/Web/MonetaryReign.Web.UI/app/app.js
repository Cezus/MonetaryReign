/// <reference path="../typings/angularjs/angular.d.ts" />
require(['angular', 'ui-router'], function (angular) {
    angular.module('monetaryreign.services', []);
    angular.module('monetaryreign.ui', []);
    var app = angular.module('monetaryreign', ['ui.router', 'monetaryreign.services', 'monetaryreign.ui']);
    app.run(startup);
    startup.$inject = ['$location'];
    function startup($location) {
        $location.path("/dashboard");
    }
    require(['angular', 'app/app.states'], function (angular) {
        angular.bootstrap(document, ['monetaryreign']);
    });
});
//# sourceMappingURL=app.js.map