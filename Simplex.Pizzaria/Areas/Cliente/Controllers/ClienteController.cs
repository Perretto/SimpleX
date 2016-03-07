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

        public ActionResult SalvarCliente(cliente cliente)
        {
            facadeCliente = new cadastroFacade();
            Result resultado = facadeCliente.SalvarCliente(cliente);

            return Json(resultado);
        }

        //public ActionResult ClienteCadastro(Guid ClienteID)
        //{
        //    cadastroFacade facadeCliente = new cadastroFacade();
        //    cliente cliente = facadeCliente.ConsultarCliente(ClienteID);

        //    return View(cliente);
        //}

    }
}