using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        
    }
}