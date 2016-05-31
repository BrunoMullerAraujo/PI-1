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

namespace ProjetoPI.Controllers
{
    public class VendedorController : BootstrapBaseController
    {
        private MantemVendedor mantemVendedor = new MantemVendedor();

        #region Métodos Privados
        private void ObtemDadosCadastro()
        {
            var vendedor = new MantemVendedor().ObtemTodosVendedor();
            ViewBag.Vended = vendedor;
        }
        #endregion


        #region Métodos
        public ActionResult Index()
        {

            try
            {
                return View(mantemVendedor.ObtemTodosVendedor());
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return View(new List<Vendedor>());
            }


        }

        public ActionResult RecuperarVendedor(int id)
        {
            if (Session["VendedorNome"] != null)
            {

                try
                {
                    ObtemDadosCadastro();
                    var vendedor = mantemVendedor.ObtemVendedorPorId(id);
                    return View("MantemVendedor", vendedor);
                }
                catch (Exception ex)
                {
                    Error(ex.Message);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                Error("Você não pode acessar essa área!");
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult MantemVendedor()
        {

            ObtemDadosCadastro();
            return View(new Vendedor());

        }

        [HttpPost]
        public ActionResult NovoVendedor(Vendedor vendedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vendedor.Id = mantemVendedor.ObtemProximoIdVendedor();
                    mantemVendedor.NovoVendedor(vendedor);
                    Success("Vendedor cadastrado com sucesso!");
                    return RedirectToAction("Index");
                }
                return View("MantemVendedor", vendedor);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return View("MantemVendedor", vendedor);
            }
        }

        [HttpPost]
        public ActionResult AlteraVendedor(Vendedor vendedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mantemVendedor.AplicaAlteracoesVendedor(vendedor);
                    Success("Vendedor alterado com sucesso!");
                    return RedirectToAction("Index");
                }
                ObtemDadosCadastro();
                return View("MantemVendedor", vendedor);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                ModelState.Clear();
                ObtemDadosCadastro();
                return View("MantemVendedor", vendedor);
            }
        }

        [HttpPost]
        public ActionResult ValidaLoginSenha(string email, string senha)
        {
            bool Retorno = mantemVendedor.ValidaLoginSenha(email, senha);
            if (Retorno == true)
            {
                var Vendedor = mantemVendedor.BuscaVendedorLogin(email);
                Session["VendedorNome"] = Vendedor.NomeReduzido;
                Success("Login Realizado com Sucesso!");
                return RedirectToAction("Index", "Home");   
            }
            else
            {
                Error("Usuario Invalido! Vai se Fuder!");
                return RedirectToAction("LoginScreen");
            }
        }

        public ActionResult LoginScreen()
        {
            if (Session["ColaboradorLogin"] == null)
            {
                try
                {
                    return View("LoginScreen");
                }
                catch (Exception ex)
                {
                    Error(ex.Message);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                Success("Já existe um vendedor logado! Sai fora!"); 
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}