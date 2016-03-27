define(["require", "exports", 'angular'], function (require, exports, angular) {
    angular
        .module('monetaryreign.services')
        .factory('dataservice', dataservice);
    dataservice.$inject = ['$http', 'moment'];
    function dataservice($http, moment) {
        return {
            getData: getData
        };
        function getData() {
            var baseUrl = document.getElementById('base-url').getAttribute('value');
            return $http.get(baseUrl + 'data/201504-201601.json')
                .then(getDataComplete);
            function getDataComplete(response) {
                return response.data;
            }
        }
    }
});
//# sourceMappingURL=data.service.js.map