using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.EntityClient;
using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Vendedor
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public string CodigoVendedor { get; set; }

        [Required(ErrorMessage = "Informe o nome do Vendedor")]
        [StringLength(35, ErrorMessage = "Máximo de 35 caracteres")]
        [Display(Name = "Descrição do Vendedor")]
        public string NomeVendedor { get; set; }

        [Required(ErrorMessage = "Informe o Nome Reduzido")]
        [StringLength(15, ErrorMessage = "Máximo de 15 caracteres")]
        [Display(Name = "Nome Reduzido")]
        public string NomeReduzido { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        [StringLength(15, ErrorMessage = "Máximo de 8 caracteres")]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o E-Mail do Vendedor")]
        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}