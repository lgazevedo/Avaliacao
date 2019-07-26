using Sistema.Entidade.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repositorio.Usuario
{
    public interface IUsuarioRepositorio
    {
        int Incluir(UsuarioDTO dto);
        void Alterar(UsuarioDTO dto);
        List<UsuarioDTO> Consultar(UsuarioDTO dto);
        void Excluir(UsuarioDTO dto);
    }
}
