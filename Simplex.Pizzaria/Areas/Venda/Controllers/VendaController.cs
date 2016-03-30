using Newtonsoft.Json;
using SimpleX.Core.Facade;
using SimpleX.Model;
using SimpleX.ModelCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Simplex.Pizzaria.Areas.Venda.Controllers
{
    public class VendaController : Controller
    {
        movimentacaoFacade facadeVenda;
        cadastroFacade facadeCadastro;
        movimentacaoFacade facadeMovimentacao;

        // GET: Venda/Venda
        public ActionResult Index()
        {
            return View();
        }

        //Listagens============================================================================================

        public ActionResult vendaListagem()
        {
            return View();
        }

        //Movimentações
        public ActionResult vendaInicio()
        {
            return View();
        }
        public ActionResult movimentacaoVenda(string idVenda = "", string idCliente = "")
        {
            venda venda = new venda();

            List<SelectListItem> itens = new List<SelectListItem>();
            facadeVenda = new movimentacaoFacade();
            facadeCadastro = new cadastroFacade();

            List<vendaStatus> lstVendaStatus = facadeVenda.ListarVendaStatus();

            for (int i = 0; i < lstVendaStatus.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstVendaStatus[i].ID.ToString(), Text = lstVendaStatus[i].nome });
            }

            itens = itens.OrderBy(s => s.Text).ToList();

            @ViewBag.status = itens;

            if (idVenda != "" && idVenda != null)
            {
                venda = facadeVenda.ConsultarVenda(Guid.Parse(idVenda));


                venda.cliente = new cliente();
                venda.cliente = facadeCadastro.ConsultarCliente(venda.clienteID);

                vendaProduto vendaProduto = new SimpleX.Model.vendaProduto();
                vendaProduto.vendaID = venda.ID;
                venda.vendaProdutos = facadeVenda.FiltrarVendaProduto(vendaProduto);

                for (int i = 0; i < venda.vendaProdutos.Count; i++)
                {
                    venda.vendaProdutos[i].produto = facadeCadastro.ConsultarProduto(venda.vendaProdutos[i].produtoID);
                    venda.vendaProdutos[i].produto.produtoCategoria = facadeCadastro.ConsultarProdutoCategoria(venda.vendaProdutos[i].produto.produtoCategoriaID);
                    venda.vendaProdutos[i].produto.produtoTipo = facadeCadastro.ConsultarProdutoTipo(venda.vendaProdutos[i].produto.produtoTipoID);
                }

                return View(venda);
            }
            else
            {
                if (idCliente != "" && idCliente != null)
                {
                    if (venda.ID == Guid.Empty || venda.ID == null)
                    {
                        venda.clienteID = Guid.Parse(idCliente);
                        venda.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
                        venda.vendaStatusID = Guid.Parse("9e3fb8c8-e790-4db1-9abd-84597ec02648");
                        venda.numeroPedido = facadeVenda.BuscarUltimoPedido(Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02"));
                        venda.numeroPedido += 1;
                        Result resultado = facadeVenda.SalvarVenda(venda);
                    }
                    

                    venda.cliente = new cliente();
                    venda.cliente = facadeCadastro.ConsultarCliente(Guid.Parse(idCliente));

                }
                else
                {
                    return View("vendaInicio", venda);
                }
            }

            return RedirectToAction("movimentacaoVenda", routeValues: new { idVenda = venda.ID });
            //return View(venda);
        }
        public ActionResult vendaProdutoCadastro(string idVenda = "")
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            facadeCadastro = new cadastroFacade();

            List<produtoCategoria> lstProdutoCategoria = facadeCadastro.ListarProdutoCategoria();

            for (int i = 0; i < lstProdutoCategoria.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstProdutoCategoria[i].ID.ToString(), Text = lstProdutoCategoria[i].nome });
            }

            @ViewBag.produtoCategorias = itens;
            itens = new List<SelectListItem>();

            List<produtoTipo> lstProdutoTipo = facadeCadastro.ListarProdutoTipo();

            for (int i = 0; i < lstProdutoTipo.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstProdutoTipo[i].ID.ToString(), Text = lstProdutoTipo[i].nome });
            }

            @ViewBag.produtoTipos = itens;



            vendaProduto vendaProduto = new SimpleX.Model.vendaProduto();
            if (idVenda != "")
            {
                vendaProduto.vendaID = Guid.Parse(idVenda);
            }



            return View("vendaProdutoCadastro", vendaProduto);
        }

        public ActionResult vendaProdutoCadastroEdicao(string idVendaProduto = "")
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            facadeCadastro = new cadastroFacade();
            facadeMovimentacao = new movimentacaoFacade();

            List<produtoCategoria> lstProdutoCategoria = facadeCadastro.ListarProdutoCategoria();

            for (int i = 0; i < lstProdutoCategoria.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstProdutoCategoria[i].ID.ToString(), Text = lstProdutoCategoria[i].nome });
            }

            @ViewBag.produtoCategorias = itens;
            itens = new List<SelectListItem>();

            List<produtoTipo> lstProdutoTipo = facadeCadastro.ListarProdutoTipo();

            for (int i = 0; i < lstProdutoTipo.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstProdutoTipo[i].ID.ToString(), Text = lstProdutoTipo[i].nome });
            }

            @ViewBag.produtoTipos = itens;

            vendaProduto vendaProduto = new SimpleX.Model.vendaProduto();
            if (idVendaProduto != "")
            {
                vendaProduto = facadeMovimentacao.ConsultarVendaProduto(Guid.Parse(idVendaProduto));

                produto produto = facadeCadastro.ConsultarProduto(vendaProduto.produtoID);
                @ViewBag.nomeProduto = produto.nome;
            }


            return View("vendaProdutoCadastro", vendaProduto);
        }
        public PartialViewResult PartialVendaClienteListagem(string pesquisarcliente)
        {
            facadeCadastro = new cadastroFacade();
            cliente cliente = new cliente();
            cliente.razaoSocial = pesquisarcliente;
            //cliente.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            List<cliente> lstCliente = facadeCadastro.FiltrarCliente(cliente);

            for (int i = 0; i < lstCliente.Count; i++)
            {
                for (int j = 0; j < lstCliente[i].clientesEnderecos.Count; j++)
                {
                    lstCliente[i].clientesEnderecos[j].cliente = new cliente();
                }

                for (int j = 0; j < lstCliente[i].clientesContatos.Count; j++)
                {
                    lstCliente[i].clientesContatos[j].cliente = new cliente();
                }
            }

            return PartialView(lstCliente);
        }



        public PartialViewResult partialVendaListagem(string pesquisarvendapedido, string pesquisarvendacliente)
        {
            facadeVenda = new movimentacaoFacade();
            facadeCadastro = new cadastroFacade();

            venda venda = new venda();
            List<venda> lstVenda = new List<venda>();

            if (pesquisarvendapedido != "" && pesquisarvendapedido != "Pesquisar pedido..." && pesquisarvendapedido != null)
            {
                venda.numeroPedido = Convert.ToInt32(pesquisarvendapedido);
                venda.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
                lstVenda = facadeVenda.FiltrarVenda(venda);

                for (int i = 0; i < lstVenda.Count; i++)
                {
                    lstVenda[i].cliente = facadeCadastro.ConsultarCliente(lstVenda[i].clienteID);
                }
            }

            if (pesquisarvendacliente != "" && pesquisarvendacliente != "Pesquisar cliente..." && pesquisarvendacliente != null)
            {
                cliente cliente = new cliente();
                cliente.razaoSocial = pesquisarvendacliente;
                List<cliente> lstcliente = facadeCadastro.FiltrarCliente(cliente);

                for (int i = 0; i < lstcliente.Count; i++)
                {
                    venda.clienteID = lstcliente[i].ID;
                    //venda.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
                    List<venda>  lstVendaCliente = facadeVenda.FiltrarVenda(venda);

                    for (int k = 0; k < lstVendaCliente.Count; k++)
                    {
                        lstVenda.Add(lstVendaCliente[k]);
                    }
                }
                

                for (int j = 0; j < lstVenda.Count; j++)
                {
                    lstVenda[j].cliente = facadeCadastro.ConsultarCliente(lstVenda[j].clienteID);
                }
            }

            return PartialView(lstVenda);
        }

        //public PartialViewResult partialVendaProdutoListagem(string pesquisarvendaproduto)
        //{
        //    facadeProduto = new cadastroFacade();
        //    produto produto = new produto();
        //    produto.nome = pesquisarproduto;
        //    //produto.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
        //    List<produto> lstProduto = facadeProduto.FiltrarProduto(produto);

        //    return PartialView(lstProduto);
        //}

        //Cadastros============================================================================================

        //public ActionResult produtoCadastro()
        //{
        //    List<SelectListItem> itens = new List<SelectListItem>();
        //    facadeProduto = new cadastroFacade();

        //    List<produtoCategoria> lstProdutoCategoria = facadeProduto.ListarProdutoCategoria();

        //    for (int i = 0; i < lstProdutoCategoria.Count; i++)
        //    {
        //        itens.Add(new SelectListItem { Value = lstProdutoCategoria[i].ID.ToString(), Text = lstProdutoCategoria[i].nome });
        //    }

        //    @ViewBag.produtoCategorias = itens;
        //    itens = new List<SelectListItem>();

        //    List<produtoTipo> lstProdutoTipo = facadeProduto.ListarProdutoTipo();

        //    for (int i = 0; i < lstProdutoTipo.Count; i++)
        //    {
        //        itens.Add(new SelectListItem { Value = lstProdutoTipo[i].ID.ToString(), Text = lstProdutoTipo[i].nome });
        //    }

        //    @ViewBag.produtoTipos = itens;

        //    produto produto = new produto();
        //    produto.produtoCategoria = new produtoCategoria();
        //    produto.produtoTipo = new produtoTipo();

        //    return View(produto);
        //}

        //public ActionResult produtoCadastroEdicao(string idProduto = "")
        //{
        //    List<SelectListItem> itens = new List<SelectListItem>();
        //    cadastroGeralFacade = new cadastroGeralFacade();
        //    facadeProduto = new cadastroFacade();


        //    List<produtoCategoria> lstProdutoCategoria = facadeProduto.ListarProdutoCategoria();

        //    for (int i = 0; i < lstProdutoCategoria.Count; i++)
        //    {
        //        itens.Add(new SelectListItem { Value = lstProdutoCategoria[i].ID.ToString(), Text = lstProdutoCategoria[i].nome });
        //    }

        //    @ViewBag.produtoCategorias = itens;
        //    itens = new List<SelectListItem>();

        //    List<produtoTipo> lstProdutoTipo = facadeProduto.ListarProdutoTipo();

        //    for (int i = 0; i < lstProdutoTipo.Count; i++)
        //    {
        //        itens.Add(new SelectListItem { Value = lstProdutoTipo[i].ID.ToString(), Text = lstProdutoTipo[i].nome });
        //    }

        //    @ViewBag.produtoTipos = itens;

        //    produto produto = new SimpleX.Model.produto();
        //    if (idProduto != "")
        //    {
        //        produto = facadeProduto.ConsultarProduto(Guid.Parse(idProduto));
        //    }


        //    return View("produtoCadastro", produto);
        //}

        //Salvar============================================================================================
        [HttpPost]
        public ActionResult salvarVenda(venda venda)
        {
            facadeVenda = new movimentacaoFacade();
            Result resultado = facadeVenda.SalvarVenda(venda);
            if (venda.ID != Guid.Empty)
            {
                resultado.AddMensagem("ID", venda.ID.ToString());
                resultado.Sucesso = true;
            }

            return Json(resultado);
        }

        public ActionResult salvarVendaProduto(vendaProduto vendaProduto)
        {
            facadeVenda = new movimentacaoFacade();
                
            vendaProduto.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            //vendaProduto.produtoID = Guid.Parse("43e0d280-cfd0-430a-afae-9a6f1520841b");
            Result resultado = facadeVenda.SalvarVendaProduto(vendaProduto);
            if (vendaProduto.ID != Guid.Empty)
            {
                resultado.AddMensagem("ID", vendaProduto.ID.ToString());
                resultado.Sucesso = true;

                vendaProduto vendaProdutoTotal = new vendaProduto();
                vendaProdutoTotal.vendaID = vendaProduto.vendaID;
                List<vendaProduto> lstvendaProduto = facadeVenda.FiltrarVendaProduto(vendaProdutoTotal);

                decimal valorTotal = lstvendaProduto.Sum(v => v.valorTotal);

                venda venda = facadeVenda.ConsultarVenda(vendaProdutoTotal.vendaID);
                venda.valorTotal = valorTotal;
                facadeVenda.SalvarVenda(venda);
            }

            return Json(resultado);
        }

        public JsonResult buscarProduto(string Filtro = "")
        {
            facadeCadastro = new cadastroFacade();
            produto produto = new SimpleX.Model.produto();
            produto.nome = Filtro;
            List<produto> lstProduto = facadeCadastro.FiltrarProduto(produto);

            return Json(lstProduto, JsonRequestBehavior.AllowGet);
        }

        ////Excluir============================================================================================
        //public ActionResult ExcluirProduto(string idProduto = "")
        //{
        //    facadeProduto = new cadastroFacade();
        //    Result resultado = new Result();

        //    if (idProduto != "")
        //    {
        //        resultado = facadeProduto.ExcluirProduto(Guid.Parse(idProduto));
        //    }
        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}

    }
}