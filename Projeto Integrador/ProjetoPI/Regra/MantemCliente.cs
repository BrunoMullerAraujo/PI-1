using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Regra;
using Persistencia;
using System.Linq.Expressions;

namespace Regra
{
    public class MantemCliente
    {
        private UnidadeDeTrabalho unidadedetrabalho = new UnidadeDeTrabalho();
        private const string OrigemLog = "ProjetoPI[Regra.MantemCliente]";

        public void NovoCliente(Cliente cliente)
        {
            try
            {
                unidadedetrabalho.ClienteRepositorio.InsereCliente(cliente);
                unidadedetrabalho.SalvaAlteracoes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public List<Cliente> ObtemTodosClientes()
        {
            try
            {
                return unidadedetrabalho.ClienteRepositorio.ObtemTodosClientes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public Cliente ObtemClientePorId(int id)
        {
            try
            {
                return unidadedetrabalho.ClienteRepositorio.ObtemClientePorId(id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public void AplicaAlteracoesCliente(Cliente cliente)
        {
            try
            {
                //colaborador.Senha = Encrypt(colaborador.Senha);
                unidadedetrabalho.ClienteRepositorio.AtualizaCliente(cliente);
                unidadedetrabalho.SalvaAlteracoes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public int ObtemProximoIdCliente()
        {
            var ultimoId = unidadedetrabalho.ClienteRepositorio.ObtemUltimoIdCliente();
            var proximoId = ultimoId + 1;
            return proximoId;
        }
    }
}
