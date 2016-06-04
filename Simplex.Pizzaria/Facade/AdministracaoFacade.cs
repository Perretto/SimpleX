using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simplex.Pizzaria.Models;
using Simplex.Pizzaria.Service;
using SimpleX.ModelCore;

namespace Simplex.Pizzaria.Facade
{
    public class administracaoFacade
    {
        private empresaService<empresa> serviceEmpresa;
        private empresaEnderecoService<empresaEndereco> serviceEmpresaEndereco;
        private usuarioService<usuario> serviceUsuario;
        private URAService<URA> serviceURA;

        public administracaoFacade()
        {
            serviceEmpresa = new empresaService<empresa>();
            serviceEmpresaEndereco = new empresaEnderecoService<empresaEndereco>();
            serviceUsuario = new usuarioService<usuario>();
            serviceURA = new URAService<URA>();
        }

        public void Dispose()
        {
            serviceEmpresa.Dispose();
            serviceEmpresaEndereco.Dispose();
            serviceUsuario.Dispose();
        }

        #region Empresa //Empresa==============================================================
        public List<empresa> FiltrarEmpresa(empresa empresa)
        {
            return serviceEmpresa.Filtrar(empresa);
        }

        public empresa ConsultarEmpresa(Guid Id)
        {
            return serviceEmpresa.Consultar(Id);
        }

        public List<empresa> ListarEmpresa()
        {
            return serviceEmpresa.Listar();
        }

        public Result SalvarEmpresa(empresa empresa)
        {
            Result retorno = serviceEmpresa.Salvar(empresa);
            return retorno;
        }

        public Result ExcluirEmpresa(Guid Id)
        {
            return serviceEmpresa.Excluir(Id);
        }

        #endregion Empresa //=====================================================================

        #region EmpresaEndereço //EmpresaEndereço==============================================================
        public List<empresaEndereco> FiltrarEmpresaEndereco(empresaEndereco empresaEndereco)
        {
            return serviceEmpresaEndereco.Filtrar(empresaEndereco);
        }

        public empresaEndereco ConsultarEmpresaEndereco(Guid Id)
        {
            return serviceEmpresaEndereco.Consultar(Id);
        }

        public List<empresaEndereco> ListarEmpresaEndereco()
        {
            return serviceEmpresaEndereco.Listar();
        }

        public Result SalvarEmpresaEndereco(empresaEndereco empresaEndereco)
        {
            Result retorno = serviceEmpresaEndereco.Salvar(empresaEndereco);
            return retorno;
        }

        public Result ExcluirEmpresaEndereco(Guid Id)
        {
            return serviceEmpresaEndereco.Excluir(Id);
        }

        #endregion EmpresaEndereco //=====================================================================

        #region Usuário //Usuário==============================================================
        public List<usuario> FiltrarUsuario(usuario usuario)
        {
            return serviceUsuario.Filtrar(usuario);
        }

        public usuario ConsultarUsuario(Guid Id)
        {
            return serviceUsuario.Consultar(Id);
        }

        public List<usuario> ListarUsuario()
        {
            return serviceUsuario.Listar();
        }

        public Result SalvarUsuario(usuario usuario)
        {
            Result retorno = serviceUsuario.Salvar(usuario);
            return retorno;
        }

        public Result ExcluirUsuario(Guid Id)
        {
            return serviceUsuario.Excluir(Id);
        }

        #endregion Usuario //=====================================================================

        #region URA //URA==============================================================
        public List<URA> FiltrarURA(URA URA)
        {
            return serviceURA.Filtrar(URA);
        }

        public URA ConsultarURA(Guid Id)
        {
            return serviceURA.Consultar(Id);
        }

        public List<URA> ListarURA()
        {
            return serviceURA.Listar();
        }

        public Result SalvarURA(URA URA)
        {
            Result retorno = serviceURA.Salvar(URA);
            return retorno;
        }

        public Result ExcluirURA(Guid Id)
        {
            return serviceURA.Excluir(Id);
        }

        #endregion URA //=====================================================================
    }
}
