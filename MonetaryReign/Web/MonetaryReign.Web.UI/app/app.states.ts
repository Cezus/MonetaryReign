/// <reference path="../typings/angularjs/angular.d.ts" />
import angular = require('angular');
import dashboard = require('app/dashboard/dashboard.controller');

function routes($stateProvider: ng.ui.IStateProvider, $urlRouterProvider: ng.ui.IUrlRouterProvider) {
    var f = dashboard
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

routes.$inject = ['$stateProvider', '$urlRouterProvider'];

angular
    .module('monetaryreign')
    .config(routes);