using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidade.Usuario;

namespace Sistema.Servico.Usuario.Implementacao
{
    public class UsuarioServicoWCF : IUsuarioServico
    {
        public void Alterar(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDTO> Consultar(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public int Incluir(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public void Excluir(UsuarioDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool ValidarDados(UsuarioDTO dto, bool inclusao, out string mensagem)
        {
            throw new NotImplementedException();
        }
    }
}
