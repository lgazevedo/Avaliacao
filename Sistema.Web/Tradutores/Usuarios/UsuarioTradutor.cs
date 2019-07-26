using Sistema.Entidade.Usuario;
using Sistema.Web.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.Web.Tradutores.Usuarios
{
    public static class UsuarioTradutor
    {
        public static List<UsuarioModel> TraduzirDto(List<UsuarioDTO> dtos)
        {
            if (dtos == null || dtos.Count == 0)
            {
                return new List<UsuarioModel>();
            }

            var usuariosModel = new List<UsuarioModel>();
            foreach(var usuarioDTO in dtos)
            {
                usuariosModel.Add(new UsuarioModel()
                {
                    Id = usuarioDTO.Id,
                    Endereco = usuarioDTO.Endereco,
                    Idade = usuarioDTO.Idade,
                    Nome = usuarioDTO.Nome,
                });
            }

            return usuariosModel;
        }

        public static List<UsuarioDTO> TraduzirModel(List<UsuarioModel> models)
        {
            if (models == null || models.Count == 0)
            {
                return new List<UsuarioDTO>();
            }

            var usuariosDTO = new List<UsuarioDTO>();
            foreach (var usuarioModel in models)
            {
                usuariosDTO.Add(new UsuarioDTO()
                {
                    Id = usuarioModel.Id,
                    Endereco = usuarioModel.Endereco,
                    Idade = usuarioModel.Idade,
                    Nome = usuarioModel.Nome,
                });
            }

            return usuariosDTO;
        }

        public static UsuarioModel TraduzirDto(UsuarioDTO dto)
        {
            if (dto == null)
            {
                return new UsuarioModel();
            }

            var usuariosDTO = new List<UsuarioDTO>();
            usuariosDTO.Add(dto);

            var usuariosModel = TraduzirDto(usuariosDTO);

            return usuariosModel != null && usuariosModel.Count > 0 ? usuariosModel[0] : new UsuarioModel();
        }

        public static UsuarioDTO TraduzirModel(UsuarioModel model)
        {
            if (model == null)
            {
                return new UsuarioDTO();
            }

            var usuariosModel = new List<UsuarioModel>();
            usuariosModel.Add(model);

            var usuariosDTO = TraduzirModel(usuariosModel);

            return usuariosDTO != null && usuariosDTO.Count > 0 ? usuariosDTO[0] : new UsuarioDTO();
        }
    }
}