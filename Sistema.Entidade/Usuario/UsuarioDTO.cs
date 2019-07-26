using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidade.Usuario
{
    [Serializable]
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte Idade { get; set; }
        public string Endereco { get; set; }
    }
}
