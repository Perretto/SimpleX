using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Simplex.Pizzaria.Areas.Administrador.Controllers
{
    public class URAController : Controller
    {
        // GET: Administrador/URA
        public ActionResult Index()
        {
            return View("URA");
        }
    }
}