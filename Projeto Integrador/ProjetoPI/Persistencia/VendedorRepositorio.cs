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
    public class VendedorRepositorio
    {
        private ProjetoPIContext projetoPIContext;
        public VendedorRepositorio(ProjetoPIContext projetoPIContext)
        {
            this.projetoPIContext = projetoPIContext;
        }

        public void InsereVendedor(Vendedor vendedor)
        {
            projetoPIContext.Vendedor.Add(vendedor);
        }

        public List<Vendedor> Busca(Expression<Func<Vendedor, bool>> filtroBusca = null)
        {
            IQueryable<Vendedor> query = projetoPIContext.Vendedor;

            if (filtroBusca != null)
                query = query.Where(filtroBusca);

            return query
                .AsNoTracking()
                .ToList();
        }

        public int ObtemUltimoIdVendedor()
        {
            if (projetoPIContext.Vendedor.Count() == 0)
                return 0;

            return projetoPIContext.Vendedor.Max(vendedor => vendedor.Id);
        }

        public Vendedor ObtemVendedorPorId(int id)
        {
            return projetoPIContext.Vendedor.Find(id);
        }

        public List<Vendedor> ObtemTodosVendedores()
        {
            return projetoPIContext.Vendedor.ToList();
        }

        public List<Vendedor> ObtemVendedorPorLogin(string email)
        {
            var vende = projetoPIContext.Vendedor.Where(vend => vend.Email == email).ToList();
            return vende;
        }

        public void AtualizaVendedor(Dominio.Vendedor vendedorModificado)
        {
            var registroVendedor = projetoPIContext.Entry(vendedorModificado);

            registroVendedor.State = EntityState.Unchanged;
            foreach (var name in registroVendedor.CurrentValues.PropertyNames)
            {
                registroVendedor.Property(name).IsModified = true;
            }
        }
    }
}