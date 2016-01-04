/// <reference path="../../typings/angularjs/angular.d.ts" />
import angular = require('angular');
angular
    .module('monetaryreign')
    .controller('DashboardController', DashboardController);

DashboardController.$inject = ['$scope'];

function DashboardController($scope) {
    this.test = 'And this is a test.';
}