/// <reference path="../../typings/angularjs/angular.d.ts" />
import angular = require('angular');
import 'app/services/data.service';

angular
    .module('monetaryreign')
    .controller('DashboardController', DashboardController);

DashboardController.$inject = ['$scope', 'dataservice'];

function DashboardController($scope, dataservice) {
    var vm = this;

    vm.transactions = null;

    dataservice.getData().then(function (data) {
        console.log(data);
        vm.transactions = data;
    });
}