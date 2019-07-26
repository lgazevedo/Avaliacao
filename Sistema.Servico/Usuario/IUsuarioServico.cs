using Sistema.Entidade.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Servico.Usuario
{
    public interface IUsuarioServico
    {
        void Alterar(UsuarioDTO dto);
        List<UsuarioDTO> Consultar(UsuarioDTO dto);
        int Incluir(UsuarioDTO dto);
        void Excluir(UsuarioDTO dto);
        bool ValidarDados(UsuarioDTO dto, bool inclusao, out string mensagem);
    }
}
