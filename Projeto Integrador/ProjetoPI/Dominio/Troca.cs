using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Troca
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente{ get; set; }

        public string Acondicionamento { get; set; }

        public string Temperatura { get; set; }

        [Display(Name = "Nf-e Devolução")]
        public string NotaFiscal { get; set; }

        public int CodigoProduto { get; set; }

        public string NomeProduto { get; set; }

        public int Quantidade { get; set; }

        [Display(Name = "Unidade")]
        public string UnidadeMedida { get; set; }
        
        public string Lote { get; set; }

        [Display(Name = "Data de Fabricação")]
        public DateTime? DataFabricacao { get; set; }

      
        [StringLength(45, ErrorMessage = "Máximo de 20 caracteres")]
        [Display(Name = "Problema")]
        public string Problema { get; set; }

        public Troca()
         {
               DataFabricacao = new DateTime(2015, 01, 01);
             }

        public int CodigoProduto2 { get; set; }

        public string NomeProduto2 { get; set; }

        public int Quantidade2 { get; set; }

        [Display(Name = "Unidade")]
        public string UnidadeMedida2 { get; set; }

        public string Lote2 { get; set; }

        [Display(Name = "Data de Fabricação")]
        public DateTime? DataFabricacao2 { get; set; }


        [StringLength(45, ErrorMessage = "Máximo de 20 caracteres")]
        [Display(Name = "Problema")]
        public string Problema2 { get; set; }


    }

}


