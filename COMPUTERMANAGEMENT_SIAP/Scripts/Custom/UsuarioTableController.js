var app = angular.module('Usuario', []).controller('UsuarioController', function ($scope, $http) {
    var variable = "";
    var usuario = '';
    var listaUsuario = [];

    $scope.init = function () {
        $scope.loadChange();
    };

    $scope.loadChange = function () {
        if (($scope.busqueda).length >= 3) {
            $scope.loadUsuarios($scope.busqueda);
        }
        if (($scope.busqueda).length < 3) {
            $scope.listaUsuario = [];
        }
    };

    $scope.loadUsuarios = function () {
        var url = $scope.getUrl('Usuario/WSBuscarUsuario?usuario=' + $scope.busqueda);
        $http.get(url).then(function (response) {
            var data = [];
            data = response.data;
            $scope.listaUsuario = data;
        }, function (response) {
            console.log('Algo anda mal con usuario');
        });
    };
    $scope.getUrl = function (url) {
        return 'http://localhost:50274/' + url;
    };
});