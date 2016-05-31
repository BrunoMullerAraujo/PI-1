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
    public class Cliente
    {
        public static readonly Dictionary<string, string> ListaTipo = new Dictionary<string, string>()
        {
            {"F","Física" },
            { "J", "Jurídica"}
        };

        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        public string Codigo { get; set; }
        
        [Display(Name = "Número Loja")]
        public int NumeroLoja { get; set; }

        [Required(ErrorMessage = "Informe o nome do cliente")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Numero")]
        public string Numero { get; set; }

        [Display(Name = "CEP")]
        [StringLength(8, ErrorMessage = "Máximo de 8 caracteres")]
        public string CEP { get; set; }

        [Display(Name = "Telefone")]
        public string NumeroTelefone { get; set; }

        [Required(ErrorMessage = "Informe o CPF ou CNPJ do Cliente")]
        [Display(Name = "CPF / CNPJ")]
        public string CPFCNPJ { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string InscricaoEstadual { get; set; }

        [Required(ErrorMessage = "Informe o Email do Cliente")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Tipo Cliente")]
        public string TipoCliente { get; set; }
    }
}