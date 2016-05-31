using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Linq.Expressions;

namespace Persistencia
{
    public class ProdutoRepositorio
    {
        private ProjetoPIContext projetoPIContext;

        public object produtoModificado { get; private set; }

        public ProdutoRepositorio(ProjetoPIContext projetoPIContext)
        {
            this.projetoPIContext = projetoPIContext;
        }

        public void InsereProduto(Dominio.Produto produto)
        {
            projetoPIContext.Produto.Add(produto);
        }

        public List<Produto> Busca(Expression<Func<Produto, bool>> filtroBusca = null)
        {
            IQueryable<Produto> query = projetoPIContext.Produto;

            if (filtroBusca != null)
                query = query.Where(filtroBusca);

            return query
                .AsNoTracking()
                .ToList();
        }

        public List<Produto> ObtemTodosProdutos()
        {
            return projetoPIContext.Produto.ToList();
        }

        public int ObtemUltimoIdProduto()
        {
            if (projetoPIContext.Produto.Count() == 0)
                return 0;

            return projetoPIContext.Produto.Max(produto => produto.Id);
        }

        public Produto ObtemProdutoPorId(int id)
        {
            return projetoPIContext.Produto.Find(id);
        }


        public void AtualizaProduto(Dominio.Produto ProdutoModificado)
        {
            var registroProduto = projetoPIContext.Entry(produtoModificado);

            registroProduto.State = EntityState.Unchanged;
            foreach (var name in registroProduto.CurrentValues.PropertyNames)
            {
                registroProduto.Property(name).IsModified = true;
            }
        }
    }
}