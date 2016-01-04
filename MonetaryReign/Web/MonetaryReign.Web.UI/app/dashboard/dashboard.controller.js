define(["require", "exports", 'angular'], function (require, exports, angular) {
    angular
        .module('monetaryreign')
        .controller('DashboardController', DashboardController);
    DashboardController.$inject = ['$scope'];
    function DashboardController($scope) {
        this.test = 'And this is a test.';
    }
});
//# sourceMappingURL=dashboard.controller.js.map