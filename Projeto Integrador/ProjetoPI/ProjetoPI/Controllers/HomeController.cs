using ProjetoPI.Controllers;
using Dominio;
using Regra;
using Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoPI.Controllers
{
    public class HomeController : Controller
    {

        private MantemCliente mantemCliente = new MantemCliente();

        #region Métodos Privados
        private void ObtemDadosCadastro()
        {
            var cliente = new MantemCliente().ObtemTodosClientes();
            ViewBag.Client = cliente;
        }
        #endregion


        public ActionResult Index()
        {
            ObtemDadosCadastro();
            return View();
        }
    }
}
