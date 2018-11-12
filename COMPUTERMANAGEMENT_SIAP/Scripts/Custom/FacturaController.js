var app = angular.module('Factura', []).controller('FacturaController', function ($scope, $http) {
    var variable = "";
    var proveedor = '';
    var listaProveedores = [];
    var search = "";

    $scope.init = function () {
        $scope.loadProveedores();
    };
    $scope.loadProveedores = function () {
        var url = $scope.getUrl('Proveedor/WSProveedor');
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaProveedores = data;
            console.log(search);
        }, function (response) {
            console.log('Algo anda mal');
        });
    };

    $scope.getUrl = function (url) {
        return 'http://localhost:50274/' + url;
    };

    $scope.buscar = function () {
        console.log("llll");
    };
});