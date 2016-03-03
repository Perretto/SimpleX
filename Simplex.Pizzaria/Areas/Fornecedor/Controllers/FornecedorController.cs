using SimpleX.Core.Facade;
using SimpleX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simplex.Pizzaria.Areas.Fornecedor.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor/Fornecedor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FornecedorListagem()
        {
            return View();
        }

        //[HttpGet]
        public PartialViewResult PartialFornecedorListagem(string pesquisarfornecedor)
        {
            cadastroFacade facadeFornecedor = new cadastroFacade();
            fornecedor fornecedor = new fornecedor();
            fornecedor.razaoSocial = pesquisarfornecedor;
            fornecedor.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            List<fornecedor> lstFornecedor = facadeFornecedor.FiltrarFornecedor(fornecedor);

            for (int i = 0; i < lstFornecedor.Count; i++)
            {
                for (int j = 0; j < lstFornecedor[i].fornecedoresEnderecos.Count; j++)
                {
                    lstFornecedor[i].fornecedoresEnderecos[j].fornecedor = new fornecedor();
                }

                for (int j = 0; j < lstFornecedor[i].fornecedoresContatos.Count; j++)
                {
                    lstFornecedor[i].fornecedoresContatos[j].fornecedor = new fornecedor();
                }
            }

            return PartialView(lstFornecedor);
        }
    }
}