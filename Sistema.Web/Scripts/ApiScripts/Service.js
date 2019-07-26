
app.service("UsuarioService", function ($http) {

    this.ObterTodosUsuarios = function () {
        return $http.get("/api/UsuarioApi");
    }

    this.ObterUsuario = function (id) {
        return $http.get("/api/UsuarioApi/" + id);
    };

    this.post = function (usuario) {
        var request = $http({
            method: "post",
            url: "/api/UsuarioApi",
            data: usuario
        });
        return request;
    };  

    this.put = function (id, usuario) {
        var request = $http({
            method: "put",
            url: "/api/UsuarioApi/" + id,
            data: usuario
        });
        return request;
    };

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/UsuarioApi/" + id
        });
        return request;
    };  
});   

