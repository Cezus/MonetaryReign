define(["require", "exports", 'angular', 'app/dashboard/dashboard.controller'], function (require, exports, angular, dashboard) {
    function routes($stateProvider, $urlRouterProvider) {
        var f = dashboard;
        var baseUrl = document.getElementById('base-url').getAttribute('value');
        $stateProvider
            .state('dasboard', {
            url: '/dashboard',
            templateUrl: baseUrl + 'app/dashboard/dashboard.html',
            controller: 'DashboardController',
            controllerAs: 'vm'
        });
        $urlRouterProvider.when('', '/dashboard');
        $urlRouterProvider.otherwise('/dashboard');
    }
    routes.$inject = ['$stateProvider', '$urlRouterProvider'];
    angular
        .module('monetaryreign')
        .config(routes);
});
//# sourceMappingURL=app.states.js.map