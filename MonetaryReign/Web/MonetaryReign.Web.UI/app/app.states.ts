/// <reference path="../typings/angularjs/angular.d.ts" />
import angular = require('angular');
import 'app/dashboard/dashboard.controller';

angular
    .module('monetaryreign')
    .config(routes);

routes.$inject = ['$stateProvider', '$urlRouterProvider'];

function routes($stateProvider: ng.ui.IStateProvider, $urlRouterProvider: ng.ui.IUrlRouterProvider) {
    //var f = dashboard
    var baseUrl = document.getElementById('base-url').getAttribute('value');

    $stateProvider
        .state('dasboard', {
            url: '/',
            templateUrl: baseUrl + 'app/dashboard/dashboard.html',
            controller: 'DashboardController',
            controllerAs: 'vm'
        })

    $urlRouterProvider.otherwise('/');
}