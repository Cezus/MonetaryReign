define(["require", "exports", 'angular', 'app/dashboard/dashboard.controller'], function (require, exports, angular) {
    angular
        .module('monetaryreign')
        .config(routes);
    routes.$inject = ['$stateProvider', '$urlRouterProvider'];
    function routes($stateProvider, $urlRouterProvider) {
        //var f = dashboard
        var baseUrl = document.getElementById('base-url').getAttribute('value');
        $stateProvider
            .state('dasboard', {
            url: '/',
            templateUrl: baseUrl + 'app/dashboard/dashboard.html',
            controller: 'DashboardController',
            controllerAs: 'vm'
        });
        $urlRouterProvider.otherwise('/');
    }
});
//# sourceMappingURL=app.states.js.map