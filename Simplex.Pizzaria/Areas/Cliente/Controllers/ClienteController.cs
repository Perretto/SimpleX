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
            return View();
        }

        //[HttpGet]
        public PartialViewResult PartialClienteListagem(string pesquisarcliente)
        {
            cadastroFacade facadeCliente = new cadastroFacade();
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
        
    }
}