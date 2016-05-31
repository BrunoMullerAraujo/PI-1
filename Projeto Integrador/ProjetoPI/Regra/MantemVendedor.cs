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
    public class MantemVendedor
    {
        private UnidadeDeTrabalho unidadedetrabalho = new UnidadeDeTrabalho();
        private readonly string OrigemLog;

        public void NovoVendedor(Vendedor  vendedor)
        {
            try
            {
                unidadedetrabalho.VendedorRepositorio.InsereVendedor(vendedor);
                unidadedetrabalho.SalvaAlteracoes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public List<Vendedor> ObtemTodosVendedor()
        {
            try
            {
                return unidadedetrabalho.VendedorRepositorio.ObtemTodosVendedores();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public Vendedor ObtemVendedorPorId(int id)
        {
            try
            {
                return unidadedetrabalho.VendedorRepositorio.ObtemVendedorPorId(id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public void AplicaAlteracoesVendedor(Vendedor vendedor)
        {
            try
            {
                //colaborador.Senha = Encrypt(colaborador.Senha);
                unidadedetrabalho.VendedorRepositorio.AtualizaVendedor(vendedor);
                unidadedetrabalho.SalvaAlteracoes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public bool ValidaLoginSenha(string Login, string Senha)
        {
            var RetornoLogin = unidadedetrabalho.VendedorRepositorio.ObtemVendedorPorLogin(Login).FirstOrDefault();
            var Retorno = false;
            if (RetornoLogin != null)
            {
               if (RetornoLogin.Senha == Senha)
                {
                    Retorno = true;
                }
            }
            return Retorno;

        }
        public int ObtemProximoIdVendedor()
        {
            var ultimoId = unidadedetrabalho.VendedorRepositorio.ObtemUltimoIdVendedor();
            var proximoId = ultimoId + 1;
            return proximoId;
        }

        public Vendedor BuscaVendedorLogin(string login)
        {
            try
            {

                var vendedor = unidadedetrabalho.VendedorRepositorio.ObtemVendedorPorLogin(login).FirstOrDefault();
                return vendedor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }
    }
}
