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
    public class TrocaRepositorio
    {
        private ProjetoPIContext projetoPIContext;
        public TrocaRepositorio(ProjetoPIContext projetoPIContext)
        {
            this.projetoPIContext = projetoPIContext;
        }

        public void InsereTroca(Troca troca)
        {
            projetoPIContext.Troca.Add(troca);
        }

        public List<Troca> Busca(Expression<Func<Troca, bool>> filtroBusca = null)
        {
            IQueryable<Troca> query = projetoPIContext.Troca;

            if (filtroBusca != null)
                query = query.Where(filtroBusca);

            return query
                .AsNoTracking()
                .ToList();
        }

        public List<Troca> ObtemTodasTrocas()
        {
            return projetoPIContext.Troca.ToList();
        }
    }
}