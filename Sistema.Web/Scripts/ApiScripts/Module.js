
var app = angular.module("ApplicationModule", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
});


app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider.when('/mostrarusuarios',
        {
            templateUrl: 'Usuario/MostrarTodos',
            controller: 'MostrarUsuariosController'
        });
    $routeProvider.when('/novousuario',
        {
            templateUrl: 'Usuario/Incluir',
            controller: 'NovoUsuarioController'
        });
    $routeProvider.when("/edicaousuario",
        {
            templateUrl: 'Usuario/Editar',
            controller: 'EdicaoUsuarioController'
        });
    $routeProvider.when('/exclusaousuario',
        {
            template: ' ',
            controller: 'ExclusaoUsuarioController'
        });
    $routeProvider.otherwise(
        {
            redirectTo: '/mostrarusuarios'
        });

    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);  