using Sistema.Entidade.Usuario;
using Sistema.Servico.Usuario;
using Sistema.Servico.Usuario.Fabrica;
using Sistema.Web.Models.Usuario;
using Sistema.Web.Tradutores.Usuarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;

namespace Sistema.Web.Controllers
{
    public class UsuarioApiController : ApiController
    {
        private IUsuarioServico usuarioServico = FabricaUsuarioServico.ObterInstancia().ObterUsuarioServico();

        // GET: api/UsuarioApi
        [HttpGet]
        [ResponseType(typeof(IEnumerable<UsuarioModel>))]
        public IEnumerable<UsuarioModel> ObterUsuarios()
        {
            try
            {
                var usuariosDTO = usuarioServico.Consultar(new UsuarioDTO());
                var usuariosModel = UsuarioTradutor.TraduzirDto(usuariosDTO);

                return usuariosModel.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: api/UsuarioApi/5
        [HttpGet]
        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult ObterUsuario(int id)
        {
            try
            { 
                if (id <= 0)
                {
                    return BadRequest("Usuário inválido.");
                }

                var usuariosDTO = usuarioServico.Consultar(new UsuarioDTO() { Id = id });
                if (usuariosDTO == null && usuariosDTO.Count == 0)
                {
                    return NotFound();
                }

                var usuariosModel = UsuarioTradutor.TraduzirDto(usuariosDTO);
                return Ok(usuariosModel[0]);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/UsuarioApi
        public IHttpActionResult Post(UsuarioModel usuario)
        {
            try
            { 
                if (usuario == null)
                {
                    return BadRequest("Usuário inválido.");
                }

                var mensagem = string.Empty;
                var usuarioDTO = UsuarioTradutor.TraduzirModel(usuario);
                if (!usuarioServico.ValidarDados(usuarioDTO, true, out mensagem))
                {
                    return InternalServerError(new Exception(mensagem));
                }

                usuarioServico.Incluir(usuarioDTO);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/UsuarioApi/5
        public IHttpActionResult Put(int id, UsuarioModel usuario)
        {
            try
            { 
                if (id <= 0 || usuario == null || (id != usuario.Id))
                {
                    return BadRequest("Usuário inválido.");
                }

                var mensagem = string.Empty;
                var usuarioDTO = UsuarioTradutor.TraduzirModel(usuario);
                if (!usuarioServico.ValidarDados(usuarioDTO, false, out mensagem))
                {
                    return InternalServerError(new Exception(mensagem));
                }

                usuarioServico.Alterar(usuarioDTO);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/UsuarioApi/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Usuário inválido.");
                }
            
                usuarioServico.Excluir(new UsuarioDTO() { Id = id });
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
