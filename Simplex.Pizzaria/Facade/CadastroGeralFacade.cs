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
    public class cadastroGeralFacade
    {
        private CNAEService<CNAE> serviceCNAE;
        private cidadeService<cidade> serviceCidade;
        private estadoService<estado> serviceEstado;
        private paisService<pais> servicePais;

        public cadastroGeralFacade()
        {
            serviceCNAE = new CNAEService<CNAE>();
            serviceCidade = new cidadeService<cidade>();
            serviceEstado = new estadoService<estado>();
            servicePais = new paisService<pais>();
        }

        public void Dispose()
        {
            serviceCNAE.Dispose();
            serviceCidade.Dispose();
            serviceEstado.Dispose();
            servicePais.Dispose();
        }


        #region CNAE //CNAE==============================================================
        public List<CNAE> FiltrarCNAE(CNAE CNAE)
        {
            return serviceCNAE.Filtrar(CNAE);
        }

        public CNAE ConsultarCNAE(Guid Id)
        {
            return serviceCNAE.Consultar(Id);
        }

        public List<CNAE> ListarCNAE()
        {
            return serviceCNAE.Listar();
        }

        public Result SalvarCNAE(CNAE CNAE)
        {
            Result retorno = serviceCNAE.Salvar(CNAE);
            return retorno;
        }
        public Result AlterarCNAE(CNAE CNAE)
        {
            Result retorno = serviceCNAE.Alterar(CNAE);
            return retorno;
        }

        public Result ExcluirCNAE(Guid Id)
        {
            return serviceCNAE.Excluir(Id);
        }
        #endregion CNAE //CNAE==============================================================

        #region Cidade //Cidade==============================================================
        public List<cidade> FiltrarCidade(cidade cidade)
        {
            return serviceCidade.Filtrar(cidade);
        }

        public cidade ConsultarCidade(Guid Id)
        {
            return serviceCidade.Consultar(Id);
        }

        public List<cidade> ListarCidade()
        {
            return serviceCidade.Listar();
        }

        public Result SalvarCidade(cidade cidade)
        {
            Result retorno = serviceCidade.Salvar(cidade);
            return retorno;
        }

        public Result AlterarCidade(cidade cidade)
        {
            Result retorno = serviceCidade.Alterar(cidade);
            return retorno;
        }

        public Result ExcluirCidade(Guid Id)
        {
            return serviceCidade.Excluir(Id);
        }
        #endregion Cidade //Cidade==============================================================

        #region Estado //Estado==============================================================
        public List<estado> FiltrarEstado(estado estado)
        {
            return serviceEstado.Filtrar(estado);
        }

        public estado ConsultarEstado(Guid Id)
        {
            return serviceEstado.Consultar(Id);
        }

        public List<estado> ListarEstado()
        {
            return serviceEstado.Listar();
        }

        public Result SalvarEstado(estado estado)
        {
            Result retorno = serviceEstado.Salvar(estado);
            return retorno;
        }
        public Result AlterarEstado(estado estado)
        {
            Result retorno = serviceEstado.Alterar(estado);
            return retorno;
        }

        public Result ExcluirEstado(Guid Id)
        {
            return serviceEstado.Excluir(Id);
        }
        #endregion Estado //Estado==============================================================

        #region Pais //Pais==============================================================
        public List<pais> FiltrarPais(pais pais)
        {
            return servicePais.Filtrar(pais);
        }

        public pais ConsultarPais(Guid Id)
        {
            return servicePais.Consultar(Id);
        }

        public List<pais> ListarPais()
        {
            return servicePais.Listar();
        }

        public Result SalvarPais(pais pais)
        {
            Result retorno = servicePais.Salvar(pais);
            return retorno;
        }
        public Result AlterarPais(pais pais)
        {
            Result retorno = servicePais.Alterar(pais);
            return retorno;
        }

        public Result ExcluirPais(Guid Id)
        {
            return servicePais.Excluir(Id);
        }
        #endregion Pais //Pais==============================================================
    }
}
