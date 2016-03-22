using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleX.Core.Facade;
using SimpleX.Model;
using SimpleX.ModelCore;
using SimpleX.Core;

namespace Simplex.Pizzaria.Areas.Fornecedor.Controllers
{
    public class FornecedorController : Controller
    {
        cadastroFacade facadeFornecedor;
        cadastroGeralFacade cadastroGeralFacade;

        // GET: Fornecedor/Fornecedor
        public ActionResult index()
        {
            fornecedor fornecedor = new fornecedor();
            fornecedor.fornecedoresEnderecos = new List<fornecedorEndereco>();
            fornecedor.fornecedoresContatos = new List<fornecedorContato>();
            return View(fornecedor);
        }

        //Listagens============================================================================================

        public ActionResult fornecedorListagem()
        {
            return View();
        }

        public PartialViewResult partialFornecedorListagem(string pesquisarfornecedor)
        {
            facadeFornecedor = new cadastroFacade();
            fornecedor fornecedor = new fornecedor();
            fornecedor.razaoSocial = pesquisarfornecedor;
            //fornecedor.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
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

        //Cadastros============================================================================================

        public ActionResult fornecedorCadastro()
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();

            List<CNAE> lstCNAE = cadastroGeralFacade.ListarCNAE();

            for (int i = 0; i < lstCNAE.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstCNAE[i].ID.ToString(), Text = lstCNAE[i].codigo });
            }

            @ViewBag.CNAEs = itens;

            fornecedor fornecedor = new fornecedor();
            fornecedor.fornecedoresEnderecos = new List<fornecedorEndereco>();
            fornecedor.fornecedoresContatos = new List<fornecedorContato>();

            return View(fornecedor);
        }

        public ActionResult fornecedorCadastroEdicao(string idFornecedor = "")
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeFornecedor = new cadastroFacade();

            List<CNAE> lstCNAE = cadastroGeralFacade.ListarCNAE();

            for (int i = 0; i < lstCNAE.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstCNAE[i].ID.ToString(), Text = lstCNAE[i].codigo });
            }

            @ViewBag.CNAEs = itens;

            fornecedor fornecedor = new SimpleX.Model.fornecedor();
            if (idFornecedor != "")
            {
                fornecedor = facadeFornecedor.ConsultarFornecedor(Guid.Parse(idFornecedor));
            }


            return View("fornecedorCadastro", fornecedor);
        }

        public ActionResult fornecedorEnderecoCadastroEdicao(string idFornecedorEndereco = "")
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeFornecedor = new cadastroFacade();

            List<cidade> lstCidade = cadastroGeralFacade.ListarCidade();

            for (int i = 0; i < lstCidade.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstCidade[i].ID.ToString(), Text = lstCidade[i].codigo });
            }

            @ViewBag.cidades = itens;

            itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeFornecedor = new cadastroFacade();

            List<estado> lstEstados = cadastroGeralFacade.ListarEstado();

            for (int i = 0; i < lstEstados.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstEstados[i].ID.ToString(), Text = lstEstados[i].codigo });
            }

            @ViewBag.estados = itens;

            itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeFornecedor = new cadastroFacade();

            List<pais> lstPaises = cadastroGeralFacade.ListarPais();

            for (int i = 0; i < lstPaises.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstPaises[i].ID.ToString(), Text = lstPaises[i].codigo });
            }

            @ViewBag.paises = itens;

            fornecedorEndereco fornecedorEndereco = new SimpleX.Model.fornecedorEndereco();
            if (idFornecedorEndereco != "")
            {
                fornecedorEndereco = facadeFornecedor.ConsultarFornecedorEndereco(Guid.Parse(idFornecedorEndereco));
            }


            return View("fornecedorEnderecoCadastro", fornecedorEndereco);
        }

        public ActionResult fornecedorEnderecoCadastro(string idFornecedor = "")
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeFornecedor = new cadastroFacade();

            List<cidade> lstCidade = cadastroGeralFacade.ListarCidade();

            for (int i = 0; i < lstCidade.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstCidade[i].ID.ToString(), Text = lstCidade[i].nome });
            }

            @ViewBag.cidades = itens;

            itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeFornecedor = new cadastroFacade();

            List<estado> lstEstados = cadastroGeralFacade.ListarEstado();

            for (int i = 0; i < lstEstados.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstEstados[i].ID.ToString(), Text = lstEstados[i].nome });
            }

            @ViewBag.estados = itens;

            itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeFornecedor = new cadastroFacade();

            List<pais> lstPaises = cadastroGeralFacade.ListarPais();

            for (int i = 0; i < lstPaises.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstPaises[i].ID.ToString(), Text = lstPaises[i].nome });
            }

            @ViewBag.paises = itens;

            fornecedorEndereco fornecedorEndereco = new fornecedorEndereco();
            if (idFornecedor != "")
            {
                fornecedorEndereco.fornecedorID = Guid.Parse(idFornecedor);
            }


            return View("fornecedorEnderecoCadastro", fornecedorEndereco);
        }

        public ActionResult fornecedorContatoCadastroEdicao(string idFornecedorContato = "")
        {
            facadeFornecedor = new cadastroFacade();

            fornecedorContato fornecedorContato = new SimpleX.Model.fornecedorContato();
            if (idFornecedorContato != "")
            {
                fornecedorContato = facadeFornecedor.ConsultarFornecedorContato(Guid.Parse(idFornecedorContato));
            }

            return View("fornecedorContatoCadastro", fornecedorContato);
        }

        public ActionResult fornecedorContatoCadastro(string idFornecedor = "")
        {
            facadeFornecedor = new cadastroFacade();

            fornecedorContato fornecedorContato = new fornecedorContato();
            if (idFornecedor != "")
            {
                fornecedorContato.fornecedorID = Guid.Parse(idFornecedor);
            }

            return View("fornecedorContatoCadastro", fornecedorContato);
        }

        //Salvar============================================================================================
        [HttpPost]
        public ActionResult salvarFornecedor(fornecedor fornecedor)
        {
            facadeFornecedor = new cadastroFacade();
            Result resultado = facadeFornecedor.SalvarFornecedor(fornecedor);
            if (fornecedor.ID != Guid.Empty)
            {
                resultado.AddMensagem("ID", fornecedor.ID.ToString());
                resultado.Sucesso = true;
            }

            return Json(resultado);
        }

        public ActionResult salvarFornecedorEndereco(fornecedorEndereco fornecedorEndereco)
        {
            facadeFornecedor = new cadastroFacade();
            Result resultado = facadeFornecedor.SalvarFornecedorEndereco(fornecedorEndereco);

            return Json(resultado);
        }

        public ActionResult salvarFornecedorContato(fornecedorContato fornecedorContato)
        {
            facadeFornecedor = new cadastroFacade();
            Result resultado = facadeFornecedor.SalvarFornecedorContato(fornecedorContato);

            return Json(resultado);
        }
        //Excluir============================================================================================
        public ActionResult excluirFornecedor(string idFornecedor = "")
        {
            facadeFornecedor = new cadastroFacade();
            Result resultado = new Result();

            if (idFornecedor != "")
            {
                resultado = facadeFornecedor.ExcluirFornecedor(Guid.Parse(idFornecedor));
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult excluirFornecedorEndereco(string idFornecedorEndereco = "")
        {
            facadeFornecedor = new cadastroFacade();
            Result resultado = new Result();

            if (idFornecedorEndereco != "")
            {
                resultado = facadeFornecedor.ExcluirFornecedorEndereco(Guid.Parse(idFornecedorEndereco));
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult excluirFornecedorContato(string idFornecedorContato = "")
        {
            facadeFornecedor = new cadastroFacade();
            Result resultado = new Result();

            if (idFornecedorContato != "")
            {
                resultado = facadeFornecedor.ExcluirFornecedorContato(Guid.Parse(idFornecedorContato));
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}