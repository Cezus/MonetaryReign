/// <reference path="../typings/angularjs/angular.d.ts" />

require(['angular', 'ui-router'], (angular) => {
    angular.module('monetaryreign.services', []);
    angular.module('monetaryreign.ui', []);
    var app = angular.module('monetaryreign', ['ui.router', 'monetaryreign.services', 'monetaryreign.ui']);

    require(['angular', 'app/app.states'], (angular) => {
        angular.bootstrap(document, ['monetaryreign']);
    });
});

