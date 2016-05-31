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
    public class MantemProdutos
    {
        private UnidadeDeTrabalho unidadedetrabalho = new UnidadeDeTrabalho();
        private readonly string OrigemLog;

        public void NovoProduto(Produto produto)
        {
            try
            {
                unidadedetrabalho.ProdutoRepositorio.InsereProduto(produto);
                unidadedetrabalho.SalvaAlteracoes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public List<Produto> ObtemTodosProdutos()
        {
            try
            {
                return unidadedetrabalho.ProdutoRepositorio.ObtemTodosProdutos();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public Produto ObtemProdutoPorId(int id)
        {
            try
            {
                return unidadedetrabalho.ProdutoRepositorio.ObtemProdutoPorId(id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public void AplicaAlteracoesProduto(Produto produto)
        {
            try
            {
                //colaborador.Senha = Encrypt(colaborador.Senha);
                unidadedetrabalho.ProdutoRepositorio.AtualizaProduto(produto);
                unidadedetrabalho.SalvaAlteracoes();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry(OrigemLog, ex.ToString());
                throw ex;
            }
        }

        public int ObtemProximoIdProduto()
        {
            var ultimoId = unidadedetrabalho.ProdutoRepositorio.ObtemUltimoIdProduto();
            var proximoId = ultimoId + 1;
            return proximoId;
        }

        public static implicit operator int(MantemProdutos v)
        {
            throw new NotImplementedException();
        }
    } 
  }
