using Sistema.Entidade.Usuario;
using Sistema.Repositorio.Usuario;
using Sistema.Repositorio.Usuario.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio.Usuario
{
    public class UsuarioNegocio
    {
        IUsuarioRepositorio _repositorio = null;

        public UsuarioNegocio()
        {
            _repositorio = FabricaUsuarioRepositorio.ObterInstancia().ObterUsuarioRepositorio();
        }
        public void Alterar(UsuarioDTO dto)
        {
            _repositorio.Alterar(dto);
        }

        public List<UsuarioDTO> Consultar(UsuarioDTO dto)
        {
            return _repositorio.Consultar(dto);
        }

        public int Incluir(UsuarioDTO dto)
        {
            return _repositorio.Incluir(dto);
        }

        public void Excluir(UsuarioDTO dto)
        {
            _repositorio.Excluir(dto);
        }

        public bool ValidarDados(UsuarioDTO dto, bool inclusao, out string mensagem)
        {
            mensagem = "";

            if (dto == null)
            {
                mensagem = "Usuário inválido.";
                return false;
            }

            if (!inclusao && dto.Id <= 0)
            {
                mensagem = "Usuário para alteração inválido.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Nome))
            {
                mensagem = "O campo nome é obrigatório.";
                return false;
            }

            if (dto.Nome.Length > 50)
            {
                mensagem = "O tamanho máximo do campo nome é 50 caracteres.";
                return false;
            }

            if (dto.Idade <= 0)
            {
                mensagem = "O campo idade é obrigatório.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(dto.Endereco) && dto.Endereco.Length > 50)
            {
                mensagem = "O tamanho máximo do campo endereço é 50 caracteres.";
                return false;
            }

            return true;
        }
    }
}
