using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Persistencia
{
    public class UnidadeDeTrabalho
    {
        private ProjetoPIContext projetoPIContext = new ProjetoPIContext();
        private TransactionScope trasacao;
        private TransactionOptions configuracoesTransacao = new TransactionOptions
        {
            IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted,
            Timeout = new TimeSpan(0, 3, 0)
        };

        private VendedorRepositorio vendedorRepositorio;
        public VendedorRepositorio VendedorRepositorio
        {
            get
            {
                return vendedorRepositorio ?? (vendedorRepositorio = new VendedorRepositorio(projetoPIContext));
            }
        }

        private ProdutoRepositorio produtoRepositorio;
        public ProdutoRepositorio ProdutoRepositorio        {
            get
            {
                return produtoRepositorio ?? (produtoRepositorio = new ProdutoRepositorio(projetoPIContext));
            }
        }

        private ClienteRepositorio clienteRepositorio;
        public ClienteRepositorio ClienteRepositorio
        {
            get
            {
                return clienteRepositorio ?? (clienteRepositorio = new ClienteRepositorio(projetoPIContext));
            }
        }

        private TrocaRepositorio trocaRepositorio;
        public TrocaRepositorio TrocaRepositorio
        {
            get
            {
                return trocaRepositorio ?? (trocaRepositorio = new TrocaRepositorio(projetoPIContext));
            }
        }

        [Obsolete]
        public void SalvaAlteracoes()
        {
            projetoPIContext.SaveChanges();
        }

        public void SalvaAlteracoes(bool commitTransaction)
        {
            trasacao = trasacao ?? new System.Transactions.TransactionScope();

            projetoPIContext.SaveChanges();

            if (commitTransaction)
            {
                trasacao.Complete();
                trasacao.Dispose();
                trasacao = null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (trasacao != null)
                    {
                        trasacao.Dispose();
                        trasacao = null;
                    }

                    projetoPIContext.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}