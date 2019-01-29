var app = angular.module('Equipo', []).controller('EquipoController', function ($scope, $http) {
    var variable = "";
    var producto = '';
    var listaProductos = [];

    $scope.init = function () {
        $scope.loadProductos();
    };
    $scope.loadProductos = function () {
        var url = $scope.getUrl('Producto/WSProductos');
        $http.get(url).then(function (response) {
            $scope.listaProductos = response.data;
        }, function (response) {
            console.log('Algo anda mal');
        });
    };

    $scope.getUrl = function (url) {
        return 'http://localhost:50274/' + url;
    };
});