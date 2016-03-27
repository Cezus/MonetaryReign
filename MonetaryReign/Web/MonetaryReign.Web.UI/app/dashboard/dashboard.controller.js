define(["require", "exports", 'angular', 'app/services/data.service'], function (require, exports, angular) {
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
});
//# sourceMappingURL=dashboard.controller.js.map