using Dominio;
using Regra;
using ProjetoPI.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BootstrapMvcSample.Controllers;
using Regra.MantemTroca;

namespace ProjetoPI.Controllers
{
    public class TrocaController : BootstrapBaseController
    {
        private MantemTroca mantemTroca = new MantemTroca();
        private MantemCliente mantemCliente = new MantemCliente();


        #region Métodos Privados
        private void ObtemDadosCadastro()
        {
            var cliente = new MantemCliente().ObtemTodosClientes().OrderBy(cli=>cli.Nome);
            ViewBag.Clientes = cliente;
            var trocas = new MantemTroca().ObtemTodasTrocas();
            ViewBag.Trocas = trocas;
        }
        #endregion
        //
        // GET: /Troca/

        public ActionResult Index()
        {
            try
            {
                return View(mantemTroca.ObtemTodasTrocas());
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return View(new List<Troca>());
            }
        }



        public ActionResult MantemTroca()
        {
            ObtemDadosCadastro();
            return View(new Troca());
        }

        [HttpPost]
        public ActionResult NovaTroca(Troca troca)
        {
            mantemTroca.NovaTroca(troca);
            Success("Troca cadastrada com sucesso!");
            return RedirectToAction("MantemTroca");
        }
    }
}
