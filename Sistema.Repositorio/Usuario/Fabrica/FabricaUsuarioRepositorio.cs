using Sistema.Repositorio.Usuario.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repositorio.Usuario.Fabrica
{
    public class FabricaUsuarioRepositorio
    {
        private static FabricaUsuarioRepositorio _instancia;
        private static IUsuarioRepositorio _repositorio;
        private static object syncLock = new object();

        private FabricaUsuarioRepositorio()
        {

        }

        public static FabricaUsuarioRepositorio ObterInstancia()
        {
            if (_instancia == null)
            {
                lock (syncLock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new FabricaUsuarioRepositorio();
                    }
                }
            }

            return _instancia;
        }

        public IUsuarioRepositorio ObterUsuarioRepositorio()
        {
            return this.ObterUsuarioRepositorioImplementacaoMemoria();
        }

        private IUsuarioRepositorio ObterUsuarioRepositorioImplementacaoSqlServer()
        {
            if (_repositorio == null)
            {
                lock (syncLock)
                {
                    if (_repositorio == null)
                    {
                        _repositorio = new UsuarioRepositorioSqlServer();
                    }
                }
            }

            return _repositorio;
        }

        private IUsuarioRepositorio ObterUsuarioRepositorioImplementacaoMemoria()
        {
            if (_repositorio == null)
            {
                lock (syncLock)
                {
                    if (_repositorio == null)
                    {
                        _repositorio = new UsuarioRepositorioMemoria();
                    }
                }
            }

            return _repositorio;
        }
    }
}
