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
    public class ProdutoController : BootstrapBaseController
    {
        private MantemProdutos mantemProdutos = new MantemProdutos();

        #region Métodos Privados
        private void ObtemDadosCadastro()
        {
            var produto = new MantemProdutos().ObtemTodosProdutos();
            ViewBag.Prodt = produto;
        }
        #endregion


        #region Métodos
        public ActionResult Index()
        {

            try
            {
                return View(mantemProdutos.ObtemTodosProdutos());
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return View(new List<Produto>());
            }


        }

        public ActionResult RecuperarProduto(int id)
        {

            try
            {
                ObtemDadosCadastro();
                var produto = mantemProdutos.ObtemProdutoPorId(id);
                return View("MantemProdutos", produto);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return RedirectToAction("Index");
            }

        }

        public ActionResult MantemProdutos()
        {

            ObtemDadosCadastro();
            return View(new Produto());

        }

        [HttpPost]
        public ActionResult NovoProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produto.Id = mantemProdutos.ObtemProximoIdProduto();
                    mantemProdutos.NovoProduto(produto);
                    Success("Produto cadastrado com sucesso!");
                    return RedirectToAction("Index");
                }
                return View("MantemProdutos", produto);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                return View("MantemProdutos", produto);
            }
        }

        private void ObtemProximoIdProduto()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult AlteraProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    mantemProdutos.AplicaAlteracoesProduto(produto);
                    Success("Produto alterado com sucesso!");
                    return RedirectToAction("Index");
                }
                ObtemDadosCadastro();
                return View("MantemProdutos", produto);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                ModelState.Clear();
                ObtemDadosCadastro();
                return View("MantemProdutos", produto);
            }
        }


        #endregion

        private bool ThumbnailCallback()
        {
            return false;
        }
    }
}