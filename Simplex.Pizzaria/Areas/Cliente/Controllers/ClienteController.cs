using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleX.Core.Facade;
using SimpleX.Model;

namespace Simplex.Pizzaria.Areas.Cliente.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClienteListagem()
        {
            cadastroFacade facadeCliente = new cadastroFacade();
            cliente cliente = new cliente();

            cliente.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            List<cliente> lstCliente = facadeCliente.FiltrarCliente(cliente);

            return View(lstCliente);
        }

        public ActionResult ClienteCadastro()
        {
            return View();
        }

        //public ActionResult ClienteCadastro(Guid ClienteID)
        //{
        //    cadastroFacade facadeCliente = new cadastroFacade();
        //    cliente cliente = facadeCliente.ConsultarCliente(ClienteID);

        //    return View(cliente);
        //}

    }
}