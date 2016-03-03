using SimpleX.Core.Facade;
using SimpleX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simplex.Pizzaria.Areas.Produto.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto/Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProdutoListagem()
        {
            return View();
        }

        //[HttpGet]
        public PartialViewResult PartialProdutoListagem(string pesquisarproduto)
        {
            cadastroFacade facadeProduto = new cadastroFacade();
            produto produto = new produto();
            produto.nome = pesquisarproduto;
            produto.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            List<produto> lstProduto = facadeProduto.FiltrarProduto(produto);
            
            return PartialView(lstProduto);
        }
    }
}