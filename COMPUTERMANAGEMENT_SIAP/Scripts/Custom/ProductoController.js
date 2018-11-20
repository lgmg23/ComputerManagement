var app = angular.module('Producto', []).controller('ProductoController', function ($scope, $http) {
    var variable = "";
    var tipo = '';
    var listaTipo = [];
    var marca = '';
    var listaMarca = [];
    var modelo = '';
    var listaModelo = [];
    var sistemaO = '';
    var listaSistemaO = [];
    var factura = '';
    var listaFactura = [];


    $scope.init = function () {
        $scope.loadTipo();
        $scope.loadMarca();
        $scope.loadFactura();
        $scope.loadSistemaO();
        $scope.loadModelo();
    };
    $scope.loadTipo = function () {
        var url = $scope.getUrl('Tipo/WSTipo');
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaTipo = data;
        }, function (response) {
            console.log('Algo anda mal con tipo');
        });
    };
    $scope.loadMarca = function () {
        var url = $scope.getUrl('Marca/WSMarca');
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaMarca = data;
        }, function (response) {
            console.log('Algo anda mal con marca');
        });
    };
    $scope.loadSistemaO = function () {
        var url = $scope.getUrl('SistemaO/WSSistemaO');
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaSistemaO = data;
        }, function (response) {
            console.log('Algo anda mal con sistema');
        });
    };
    $scope.loadFactura = function () {
        var url = $scope.getUrl('Factura/WSFactura');
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaFactura = data;
        }, function (response) {
            console.log('Algo anda mal con factura');
        });
    };
    $scope.loadModelo = function () {
        var url = $scope.getUrl('Modelo/WSModelo');
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaModelo = data;
        }, function (response) {
            console.log('Algo anda mal con modelo');
        });
    };


    $scope.getUrl = function (url) {
        return 'http://localhost:50274/' + url;
    };
});