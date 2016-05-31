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

namespace Controllers
{
    public class ClienteController : BootstrapBaseController
    {
        private MantemCliente mantemCliente = new MantemCliente();

        #region Métodos Privados
        private void ObtemDadosCadastro()
        {
            var cliente = new MantemCliente().ObtemTodosClientes();
            ViewBag.Client = cliente;
        }
        #endregion


        #region Métodos
        public ActionResult Index()
        {

                try
                {
                    return View(mantemCliente.ObtemTodosClientes());
                }
                catch (Exception ex)
                {
                    Error(ex.Message);
                    return View(new List<Cliente>());
                }
           

        }

        public ActionResult RecuperarCliente(int id)
        {

                try
                {
                    ObtemDadosCadastro();
                    var cliente = mantemCliente.ObtemClientePorId(id);
                    return View("MantemCliente", cliente);
                }
                catch (Exception ex)
                {
                    Error(ex.Message);
                    return RedirectToAction("Index");
                }

        }

        public ActionResult MantemCliente()
        {

                ObtemDadosCadastro();
                return View(new Cliente());
    
        }

        [HttpPost]
        public ActionResult NovoCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cliente.Id = mantemCliente.ObtemProximoIdCliente();
                    mantemCliente.NovoCliente(cliente);
                    Success("Cliente cadastrado com sucesso!");
                    return RedirectToAction("Index");
                }
                return View("MantemCliente", cliente);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return View("MantemCliente", cliente);
            }
        }

        [HttpPost]
        public ActionResult AlteraCliente(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mantemCliente.AplicaAlteracoesCliente(cliente);
                    Success("Cliente alterado com sucesso!");
                    return RedirectToAction("Index");
                }
                ObtemDadosCadastro();
                return View("MantemCliente", cliente);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                ModelState.Clear();
                ObtemDadosCadastro();
                return View("MantemCliente", cliente);
            }
        }

        public ActionResult BuscaClienteIdParaTroca(int idCliente)
        {
            var clientes = mantemCliente.ObtemClientePorId(idCliente);
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }
       
        #endregion

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}