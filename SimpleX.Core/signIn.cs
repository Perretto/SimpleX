using SimpleX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Core
{
    public class signIn
    {
        public string PasswordSignIn(string email, string senha)
        {
            usuario usuario = new usuario();
            Facade.administracaoFacade facadeAdmin = new Facade.administracaoFacade();
            List<usuario> lstUsuario = new List<Model.usuario>();
            string retorno = "Failure";
            usuario.email = email;
            usuario.senha = senha;
            lstUsuario = facadeAdmin.FiltrarUsuario(usuario);

            if (lstUsuario.Count > 0)
            {
                retorno = "Success";
            }


            return retorno;
        }
    }
}
