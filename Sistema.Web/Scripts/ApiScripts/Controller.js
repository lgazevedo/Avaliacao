
app.controller("MostrarUsuariosController", function ($scope, $location, UsuarioService, ShareData) {
    MostrarTodosUsuarios();

    function MostrarTodosUsuarios() {
        var servico = UsuarioService.ObterTodosUsuarios();

        servico.then(function (response) {
            $scope.usuarios = response.data;
        }, function (error) {
            $scope.error = 'Erro ao consultar todos usuários : ' + error.data.ExceptionMessage;
        })
    }

    $scope.edicaoUsuario = function (id) {
        ShareData.value = id;
        $location.path("/edicaousuario");
    }

    $scope.exclusaoUsuario = function (id) {
        ShareData.value = id;
        $location.path("/exclusaousuario");
    }  
});

app.controller('NovoUsuarioController', function ($scope, $location, UsuarioService) {
    $scope.Id = 0;

    $scope.salvar = function () {
        
        var usuario = {
            Id: 0,
            Nome: $scope.Nome,
            Idade: $scope.Idade,
            Endereco: $scope.Endereco,
        };

        var servico = UsuarioService.post(usuario);

        servico.then(function (response) {
            alert("Usuário salvo com sucesso.");
            $location.path("/mostrarusuarios");
        }, function (error) {
            $scope.error = 'Erro ao salvar o usuário : ' + error.data.ExceptionMessage;
        });
    };

    $scope.voltar = function () {
        $location.path("/mostrarusuarios");
    }
});

app.controller("EdicaoUsuarioController", function ($scope, $location, ShareData, UsuarioService) {
    ObterUsuario();

    function ObterUsuario() {
        var servico = UsuarioService.ObterUsuario(ShareData.value);

        servico.then(function (response) {
            $scope.usuario = response.data;
        }, function (error) {
            $scope.error = 'Erro ao consultar o usuário : ' + error.data.ExceptionMessage;
        });
    }

    $scope.salvar = function () {
        var usuario = {
            Id: $scope.usuario.Id,
            Nome: $scope.usuario.Nome,
            Idade: $scope.usuario.Idade,
            Endereco: $scope.usuario.Endereco,
        };

        var servico = UsuarioService.put($scope.usuario.Id, usuario);

        servico.then(function (response) {
            alert("Usuário editado com sucesso.");
            $location.path("/mostrarusuarios");
        }, function (error) {
            $scope.error = 'Erro ao editar o usuário : ' + error.data.ExceptionMessage;
        });
    };

    $scope.voltar = function () {
        $location.path("/mostrarusuarios");
    }
});

app.controller("ExclusaoUsuarioController", function ($scope, $location, ShareData, UsuarioService) {
    ExcluirUsuario();

    function ExcluirUsuario() {
        var servico = UsuarioService.delete(ShareData.value);

        servico.then(function (response) {
            alert("Usuário excluído com sucesso.");
            $location.path("/mostrarusuarios");
        }, function (error) {
            alert('Erro ao excluir o usuário : ' + error.data.ExceptionMessage);
        });
    }

});  