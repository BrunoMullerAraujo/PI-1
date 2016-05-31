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
    public class ClienteRepositorio
    {
        private ProjetoPIContext projetoPIContext;
        public ClienteRepositorio(ProjetoPIContext projetoPIContext)
        {
            this.projetoPIContext = projetoPIContext;
        }

        public void InsereCliente(Cliente cliente)
        {
            projetoPIContext.Cliente.Add(cliente);
        }

        public List<Cliente> Busca(Expression<Func<Cliente, bool>> filtroBusca = null)
        {
            IQueryable<Cliente> query = projetoPIContext.Cliente;

            if (filtroBusca != null)
                query = query.Where(filtroBusca);

            return query
                .AsNoTracking()
                .ToList();
        }

        public int ObtemUltimoIdCliente()
        {
            if (projetoPIContext.Cliente.Count() == 0)
                return 0;

            return projetoPIContext.Cliente.Max(cliente => cliente.Id);
        }

        public Cliente ObtemClientePorId(int id)
        {
            return projetoPIContext.Cliente.Find(id);
        }

        public List<Cliente> ObtemTodosClientes()
        {
            return projetoPIContext.Cliente.ToList();
        }

        public void AtualizaCliente(Dominio.Cliente clienteModificado)
        {
            var registroCliente = projetoPIContext.Entry(clienteModificado);

            registroCliente.State = EntityState.Unchanged;
            foreach (var name in registroCliente.CurrentValues.PropertyNames)
            {
                registroCliente.Property(name).IsModified = true;
            }
        }
    }
}