var app = angular.module('ngOptions', []).controller('EquipoAsignarController', function ($scope, $http) {
    var variable = "";
    var estado = '';
    var listaEstados = [];
    var municipio = '';

    $scope.init = function () {
        $scope.loadUsuarios();
    };
    $scope.loadUsuarios = function () {
        var url = $scope.getUrl('Fuente/GetFuentes');
        $http.get(url).then(function (response) {
            $scope.listaFuentes = response.data;
        }, function (response) {
            console.log('valio corneta Fuente');
        });
    }
   
    $scope.getUrl = function (url) {
        //return 'http://app.sicya.com.mx/' + url;
        //return 'http://187.188.46.247/' + url;	    
        return 'http://localhost:2092/' + url;
    }

    $scope.getDireccion = function () {
        return ($scope.calle || "") + "+" +
            ($scope.numeroExterior || "") + "+" +
            ($scope.colonia ? $scope.colonia.Colonia : "") + "+" +
            ($scope.codigoPostal ? $scope.codigoPostal.CodigoPostal : "") + "+" +
            ($scope.municipio ? $scope.municipio.Municipio : "") + "+" +
            ($scope.estado ? $scope.estado.Estado : "");
    };
});