using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dominio;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
     public class Produto
    {
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public string CodigoPro { get; set; }

        [Required(ErrorMessage = "Informe a Descrição do Produto")]
        [StringLength(40, ErrorMessage = "Máximo de 40 caracteres")]
        [Display(Name = "Descrição do Produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Unidade de Medida")]
        public string UnidadeMedida { get; set; }

    }
}