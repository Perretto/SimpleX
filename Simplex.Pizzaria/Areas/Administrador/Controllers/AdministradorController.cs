using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Simplex.Pizzaria.Facade;
using Simplex.Pizzaria.Models;
using SimpleX.ModelCore;

namespace Simplex.Pizzaria.Areas.Administrador.Controllers
{
    public class AdministradorController : Controller
    {
        administracaoFacade facadeAdministrador;
        cadastroFacade facadeCadastro;

        public AdministradorController()
        {
            facadeAdministrador = new administracaoFacade();
            facadeCadastro = new cadastroFacade();
        }

        // GET: Administrador/Administrador
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult usuarioListagem()
        {
            List<empresa> lstemp = facadeAdministrador.ListarEmpresa();

            usuario usuario = new usuario();
            usuario.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            List<usuario> lstUsuario = facadeAdministrador.FiltrarUsuario(usuario);
            @ViewBag.caminho = "Usuario";

            return View(lstUsuario);
        }

        public ActionResult usuarioCadastroEdicao(string idUsuario = "")
        {
            usuario usuario = new usuario();
            if (idUsuario != "")
            {
                usuario = facadeAdministrador.ConsultarUsuario(Guid.Parse(idUsuario));
            }

            @ViewBag.caminho = "Usuario";

            return View("usuarioCadastro", usuario);
        }

        public ActionResult usuarioCadastro(string idUsuario = "")
        {
            usuario usuario = new usuario();
            if (idUsuario != "")
            {
                usuario = facadeAdministrador.ConsultarUsuario(Guid.Parse(idUsuario));
            }

            @ViewBag.caminho = "Usuario";

            return View("usuarioCadastro", usuario);
        }

        //Salvar============================================================================================
        [HttpPost]
        public ActionResult SalvarUsuario(usuario usuario)
        {
            usuario.empresaID = Guid.Parse("fc70ecab-61b8-4e53-9a99-6098b0a75a02");
            Result resultado;
            if (usuario.ID.ToString() == "" || usuario.ID == Guid.Empty)
            {
                usuario.ID = Guid.NewGuid();
                resultado = facadeAdministrador.SalvarUsuario(usuario);
            }
            else
            {
                resultado = facadeAdministrador.AlterarUsuario(usuario);
            }

            //Result resultado = facadeAdministrador.SalvarUsuario(usuario);
            if (usuario.ID != Guid.Empty)
            {
                resultado.AddMensagem("ID", usuario.ID.ToString());
                resultado.Sucesso = true;
            }

            return Json(resultado);
        }

        //Excluir============================================================================================
        public ActionResult ExcluirUsuario(string idUsuario = "")
        {
            Result resultado = new Result();

            if (idUsuario != "")
            {
                resultado = facadeAdministrador.ExcluirUsuario(Guid.Parse(idUsuario));
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}