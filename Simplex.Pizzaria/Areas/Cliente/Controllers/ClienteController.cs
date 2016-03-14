using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleX.Core.Facade;
using SimpleX.Model;
using SimpleX.ModelCore;
using SimpleX.Core;

namespace Simplex.Pizzaria.Areas.Cliente.Controllers
{
    public class ClienteController : Controller
    {
        cadastroFacade facadeCliente;
        cadastroGeralFacade cadastroGeralFacade;

        // GET: Cliente/Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClienteListagem()
        {
            return View();
        }

        //[HttpGet]
        public PartialViewResult PartialClienteListagem(string pesquisarcliente)
        {
            facadeCliente = new cadastroFacade();
            cliente cliente = new cliente();
            cliente.razaoSocial = pesquisarcliente;
            cliente.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            List<cliente> lstCliente = facadeCliente.FiltrarCliente(cliente);

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

        public ActionResult ClienteCadastro()
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();

            List<CNAE> lstCNAE = cadastroGeralFacade.ListarCNAE();

            for (int i = 0; i < lstCNAE.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstCNAE[i].ID.ToString(), Text = lstCNAE[i].codigo });
            }
            
            @ViewBag.CNAEs = itens;


            return View();
        }
        
        public ActionResult ClienteCadastroEdicao(string idCliente = "")
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeCliente = new cadastroFacade();

            List<CNAE> lstCNAE = cadastroGeralFacade.ListarCNAE();

            for (int i = 0; i < lstCNAE.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstCNAE[i].ID.ToString(), Text = lstCNAE[i].codigo });
            }

            @ViewBag.CNAEs = itens;

            cliente cliente = new SimpleX.Model.cliente();
            if (idCliente != "")
            {
                cliente = facadeCliente.ConsultarCliente(Guid.Parse(idCliente));
            }
              

            return View("ClienteCadastro", cliente);
        }

        public ActionResult ClienteEnderecoCadastroEdicao(string idClienteEndereco = "")
        {
            List<SelectListItem> itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeCliente = new cadastroFacade();

            List<cidade> lstCidade = cadastroGeralFacade.ListarCidade();

            for (int i = 0; i < lstCidade.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstCidade[i].ID.ToString(), Text = lstCidade[i].codigo });
            }

            @ViewBag.cidades = itens;

            itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeCliente = new cadastroFacade();

            List<estado> lstEstados = cadastroGeralFacade.ListarEstado();

            for (int i = 0; i < lstEstados.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstEstados[i].ID.ToString(), Text = lstEstados[i].codigo });
            }

            @ViewBag.estados = itens;

            itens = new List<SelectListItem>();
            cadastroGeralFacade = new cadastroGeralFacade();
            facadeCliente = new cadastroFacade();

            List<pais> lstPaises = cadastroGeralFacade.ListarPais();

            for (int i = 0; i < lstPaises.Count; i++)
            {
                itens.Add(new SelectListItem { Value = lstPaises[i].ID.ToString(), Text = lstPaises[i].codigo });
            }

            @ViewBag.paises = itens;

            clienteEndereco clienteEndereco = new SimpleX.Model.clienteEndereco();
            if (idClienteEndereco != "")
            {
                clienteEndereco = facadeCliente.ConsultarClienteEndereco(Guid.Parse(idClienteEndereco));
            }


            return View("ClienteEnderecoCadastro", clienteEndereco);
        }
        
        public ActionResult SalvarCliente(cliente cliente)
        {
            facadeCliente = new cadastroFacade();
            Result resultado = facadeCliente.SalvarCliente(cliente);

            return Json(resultado);
        }

        public ActionResult SalvarClienteEndereco(clienteEndereco clienteEndereco)
        {
            facadeCliente = new cadastroFacade();
            Result resultado = facadeCliente.SalvarClienteEndereco(clienteEndereco);

            return Json(resultado);
        }

        public ActionResult ExcluirCliente(string idCliente = "")
        {
            facadeCliente = new cadastroFacade();
            Result resultado = new Result();

            if (idCliente != "")
            {
                resultado = facadeCliente.ExcluirCliente(Guid.Parse(idCliente));
            }
            return Json(resultado);
        }

    }
}