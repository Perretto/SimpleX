using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleX.Core.Facade;
using SimpleX.Model;

namespace Simplex.Pizzaria.Areas.Administrador.Controllers
{
    public class URAController : Controller
    {
        // GET: Administrador/URA
        public ActionResult Index()
        {
            administracaoFacade administracaoFacade = new administracaoFacade();

            //URA lstURA = administracaoFacade.ConsultarURA(Guid.Parse("4fad24d6-d9c6-496d-a7a2-b372372606da"));
            List<URA> lstURA = administracaoFacade.ListarURA();
            return View("URA", lstURA);
        }
    }
}