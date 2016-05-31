using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dominio;
using System.Data.Entity.ModelConfiguration.Conventions;
using Persistencia;

namespace Persistencia
{
    public class ProjetoPIContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Troca> Troca { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public ProjetoPIContext()
        {
            Database.SetInitializer<ProjetoPIContext>(new CreateInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class CreateInitializer : CreateDatabaseIfNotExists<ProjetoPIContext>
    {
        protected override void Seed(ProjetoPIContext projetoPIContext)
        {

            var cliente = new Cliente
            {
                Nome = "Bruno Muller",
                Email = "brunomuller@gmail.com",
                Endereco = "Rua Rui Barbosa",
                Bairro = "Cônego Getúlio",
                Numero = "3213",
                CEP = "38700196",
                TipoCliente = "F",
                Codigo = "17172",
                CPFCNPJ = "58558720177",
                InscricaoEstadual = "211MAM2",
                NomeFantasia = "",
                NumeroLoja = 18218,
                NumeroTelefone = "3438213131"
            };


            projetoPIContext.Cliente.Add(cliente);
            projetoPIContext.SaveChanges();

            var vendedor = new Vendedor
            {
                NomeVendedor = "Bruno Muller",
                Email = "brunomuller@gmail.com",
                CodigoVendedor = "1",
                Cidade = "Patos de Minas",
                NomeReduzido = "Bruno",
                Telefone = "3438213131",
                Senha = "120996"
            };


            projetoPIContext.Vendedor.Add(vendedor);
            projetoPIContext.SaveChanges();

            var produto = new Produto
            {
                CodigoPro = "01",
                NomeProduto = "PRODUTO TESTE 1",
                UnidadeMedida = "Un",

            };


            projetoPIContext.Produto.Add(produto);
            projetoPIContext.SaveChanges();

            base.Seed(projetoPIContext);
        }
    }
}

