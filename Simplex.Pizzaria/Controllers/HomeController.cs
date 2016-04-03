using SimpleX.Model;
using SimpleX.ModelCore.Contexts;
using SimpleX.ModelCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Simplex.Pizzaria.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //empresaService empresaService = new empresaService();
            //List<empresa> lstEmpresa = empresaService.Listar();
            @ViewBag.caminho = "Dashboard";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}