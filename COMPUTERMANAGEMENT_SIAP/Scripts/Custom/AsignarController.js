var app = angular.module('Equipo', []).controller('EquipoAsignarController', function ($scope, $http){
    var variable = "";
    var usuario = '';
    var listaUsuarios = [];
    var search = "";

    $scope.init = function () {
        $scope.loadUsuarios();       
    };
    $scope.loadUsuarios = function () {
        var url = $scope.getUrl('Usuario/WSUsuarios');
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaUsuarios = data;
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