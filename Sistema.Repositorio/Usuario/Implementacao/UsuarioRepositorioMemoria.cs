using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidade.Usuario;

namespace Sistema.Repositorio.Usuario.Implementacao
{
    public class UsuarioRepositorioMemoria : IUsuarioRepositorio
    {
        private List<UsuarioDTO> _usuarios;

        public UsuarioRepositorioMemoria()
        {
            _usuarios = new List<UsuarioDTO>();
        }

        public void Alterar(UsuarioDTO dto)
        {
            var usuario = BuscarPorId(dto.Id);
            if (usuario != null)
            {
                usuario.Nome = dto.Nome;
                usuario.Idade = dto.Idade;
                usuario.Endereco = dto.Endereco;
            }
        }

        public List<UsuarioDTO> Consultar(UsuarioDTO dto)
        {
            var usuarios = new List<UsuarioDTO>();

            if (dto.Id > 0)
            {
                var usuario = BuscarPorId(dto.Id);
                if (usuario != null)
                {
                    usuarios.Add(usuario);
                }

                return usuarios;
            }

            if (!string.IsNullOrWhiteSpace(dto.Nome))
            {
                usuarios = BuscarPorNome(dto.Nome);
                return usuarios;
            }

            return _usuarios;
        }

        public void Excluir(UsuarioDTO dto)
        {
            var usuario = BuscarPorId(dto.Id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
            }
        }

        public int Incluir(UsuarioDTO dto)
        {
            var id = ObterNovoId();
            dto.Id = id;

            _usuarios.Add(dto);
            return id;
        }

        private UsuarioDTO BuscarPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }

        private List<UsuarioDTO> BuscarPorNome(string nome)
        {
            try
            {
                return _usuarios.FindAll(u => u.Nome.Contains(nome));
            }
            catch(Exception ex)
            {
                return new List<UsuarioDTO>();
            }
        }

        private int ObterNovoId()
        {
            if (_usuarios.Count == 0)
            {
                return 1;
            }

            int id = _usuarios.Max(u => u.Id);
            return id + 1;
        }
    }
}
