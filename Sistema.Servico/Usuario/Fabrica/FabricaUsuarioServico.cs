using Sistema.Servico.Usuario.Implementacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Servico.Usuario.Fabrica
{
    public class FabricaUsuarioServico
    {
        private static FabricaUsuarioServico _instancia;
        private static IUsuarioServico _servico;
        private static object syncLock = new object();

        private FabricaUsuarioServico()
        {

        }

        public static FabricaUsuarioServico ObterInstancia()
        {
            if (_instancia == null)
            {
                lock (syncLock)
                {
                    if (_instancia == null)
                    {
                        _instancia = new FabricaUsuarioServico();
                    }
                }
            }

            return _instancia;
        }

        public IUsuarioServico ObterUsuarioServico()
        {
            return this.ObterUsuarioServicoImplementacaoLocal();
        }

        private IUsuarioServico ObterUsuarioServicoImplementacaoLocal()
        {
            if (_servico == null)
            {
                lock (syncLock)
                {
                    if (_servico == null)
                    {
                        _servico = new UsuarioServicoLocal();
                    }
                }
            }

            return _servico;
        }
    }
}
