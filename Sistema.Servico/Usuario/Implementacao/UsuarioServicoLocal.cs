using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidade.Usuario;
using Sistema.Negocio.Usuario;

namespace Sistema.Servico.Usuario.Implementacao
{
    public class UsuarioServicoLocal : IUsuarioServico
    {
        UsuarioNegocio _negocio = null;

        public UsuarioServicoLocal()
        {
            _negocio = new UsuarioNegocio();
        }

        public void Alterar(UsuarioDTO dto)
        {
            _negocio.Alterar(dto);
        }

        public List<UsuarioDTO> Consultar(UsuarioDTO dto)
        {
            return _negocio.Consultar(dto);
        }

        public int Incluir(UsuarioDTO dto)
        {
            return _negocio.Incluir(dto);
        }

        public void Excluir(UsuarioDTO dto)
        {
            _negocio.Excluir(dto);
        }

        public bool ValidarDados(UsuarioDTO dto, bool inclusao, out string mensagem)
        {
            return _negocio.ValidarDados(dto, inclusao, out mensagem);
        }
    }
}
