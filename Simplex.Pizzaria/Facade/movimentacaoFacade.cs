using Simplex.Pizzaria.Service;
using SimpleX.Model;
using SimpleX.ModelCore;
using SimpleX.ModelCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplex.Pizzaria.Facade
{
    public class movimentacaoFacade
    {
        private vendaService serviceVenda;
        private Simplex.Pizzaria.Service.vendaProdutoService<Simplex.Pizzaria.Models.vendaProduto> serviceVendaProduto;
        private vendaStatusService serviceVendaStatus;
        private vendaPagamentoService serviceVendaPagamento;

        private compraService serviceCompra;
        private compraProdutoService serviceCompraProduto;
        private compraStatusService serviceCompraStatus;
        private compraPagamentoService serviceCompraPagamento;

        public movimentacaoFacade()
        {
            serviceVenda = new vendaService();
            serviceVendaProduto = new vendaProdutoService<Simplex.Pizzaria.Models.vendaProduto>();
            serviceVendaStatus = new vendaStatusService();
            serviceVendaPagamento = new vendaPagamentoService();

            serviceCompra = new compraService();
            serviceCompraProduto = new compraProdutoService();
            serviceCompraStatus = new compraStatusService();
            serviceCompraPagamento = new compraPagamentoService();
        }

        public void Dispose()
        {
            serviceVenda.Dispose();
            serviceVendaProduto.Dispose();
            serviceVendaStatus.Dispose();
            serviceVendaPagamento.Dispose();

            serviceCompra.Dispose();
            serviceCompraProduto.Dispose();
            serviceCompraStatus.Dispose();
            serviceCompraPagamento.Dispose();
        }

        #region Venda //Venda==============================================================
        public List<venda> FiltrarVenda(venda venda)
        {
            return serviceVenda.Filtrar(venda);
        }

        public venda ConsultarVenda(Guid Id)
        {
            return serviceVenda.Consultar(Id);
        }

        public List<venda> ListarVenda()
        {
            return serviceVenda.Listar();
        }

        public Result SalvarVenda(venda venda)
        {
            Result retorno = serviceVenda.Salvar(venda);
            return retorno;
        }

        public Result ExcluirVenda(Guid Id)
        {
            return serviceVenda.Excluir(Id);
        }

        public int BuscarUltimoPedido(Guid IdEmpresa)
        {
            return serviceVenda.BuscarUltimoPedido(IdEmpresa);
        }


        public List<Simplex.Pizzaria.Models.vendaProduto> FiltrarVendaProduto(Simplex.Pizzaria.Models.vendaProduto vendaProduto)
        {
            return serviceVendaProduto.Filtrar(vendaProduto);
        }

        public vendaProduto ConsultarVendaProduto(Guid Id)
        {
            return serviceVendaProduto.Consultar(Id);
        }

        public List<Simplex.Pizzaria.Models.vendaProduto> ListarVendaProduto()
        {
            return serviceVendaProduto.Listar();
        }

        public Result SalvarVendaProduto(Simplex.Pizzaria.Models.vendaProduto vendaProduto)
        {
            Result retorno = serviceVendaProduto.Salvar(vendaProduto);
            return retorno;
        }

        public Result ExcluirVendaProduto(Guid Id)
        {
            return serviceVendaProduto.Excluir(Id);
        }



        public List<vendaStatus> FiltrarVendaStatus(vendaStatus vendaStatus)
        {
            return serviceVendaStatus.Filtrar(vendaStatus);
        }

        public vendaStatus ConsultarVendaStatus(Guid Id)
        {
            return serviceVendaStatus.Consultar(Id);
        }

        public List<vendaStatus> ListarVendaStatus()
        {
            return serviceVendaStatus.Listar();
        }

        public Result SalvarVendaStatus(vendaStatus vendaStatus)
        {
            Result retorno = serviceVendaStatus.Salvar(vendaStatus);
            return retorno;
        }

        public Result ExcluirVendaStatus(Guid Id)
        {
            return serviceVendaStatus.Excluir(Id);
        }



        public List<vendaPagamento> FiltrarVendaPagamento(vendaPagamento vendaPagamento)
        {
            return serviceVendaPagamento.Filtrar(vendaPagamento);
        }

        public vendaPagamento ConsultarVendaPagamento(Guid Id)
        {
            return serviceVendaPagamento.Consultar(Id);
        }

        public List<vendaPagamento> ListarVendaPagamento()
        {
            return serviceVendaPagamento.Listar();
        }

        public Result SalvarVendaPagamento(vendaPagamento vendaPagamento)
        {
            Result retorno = serviceVendaPagamento.Salvar(vendaPagamento);
            return retorno;
        }

        public Result ExcluirVendaPagamento(Guid Id)
        {
            return serviceVendaPagamento.Excluir(Id);
        }

        #endregion Venda //=====================================================================



        #region Compra //Compra==============================================================
        public List<compra> FiltrarCompra(compra compra)
        {
            return serviceCompra.Filtrar(compra);
        }

        public compra ConsultarCompra(Guid Id)
        {
            return serviceCompra.Consultar(Id);
        }

        public List<compra> ListarCompra()
        {
            return serviceCompra.Listar();
        }

        public Result SalvarCompra(compra compra)
        {
            Result retorno = serviceCompra.Salvar(compra);
            return retorno;
        }

        public Result ExcluirCompra(Guid Id)
        {
            return serviceCompra.Excluir(Id);
        }



        public List<compraProduto> FiltrarCompraProduto(compraProduto compraProduto)
        {
            return serviceCompraProduto.Filtrar(compraProduto);
        }

        public compraProduto ConsultarCompraProduto(Guid Id)
        {
            return serviceCompraProduto.Consultar(Id);
        }

        public List<compraProduto> ListarCompraProduto()
        {
            return serviceCompraProduto.Listar();
        }

        public Result SalvarCompraProduto(compraProduto compraProduto)
        {
            Result retorno = serviceCompraProduto.Salvar(compraProduto);
            return retorno;
        }

        public Result ExcluirCompraProduto(Guid Id)
        {
            return serviceCompraProduto.Excluir(Id);
        }



        public List<compraStatus> FiltrarCompraStatus(compraStatus compraStatus)
        {
            return serviceCompraStatus.Filtrar(compraStatus);
        }

        public compraStatus ConsultarCompraStatus(Guid Id)
        {
            return serviceCompraStatus.Consultar(Id);
        }

        public List<compraStatus> ListarCompraStatus()
        {
            return serviceCompraStatus.Listar();
        }

        public Result SalvarCompraStatus(compraStatus compraStatus)
        {
            Result retorno = serviceCompraStatus.Salvar(compraStatus);
            return retorno;
        }

        public Result ExcluirCompraStatus(Guid Id)
        {
            return serviceCompraStatus.Excluir(Id);
        }



        public List<compraPagamento> FiltrarCompraPagamento(compraPagamento compraPagamento)
        {
            return serviceCompraPagamento.Filtrar(compraPagamento);
        }

        public compraPagamento ConsultarCompraPagamento(Guid Id)
        {
            return serviceCompraPagamento.Consultar(Id);
        }

        public List<compraPagamento> ListarCompraPagamento()
        {
            return serviceCompraPagamento.Listar();
        }

        public Result SalvarCompraPagamento(compraPagamento compraPagamento)
        {
            Result retorno = serviceCompraPagamento.Salvar(compraPagamento);
            return retorno;
        }

        public Result ExcluirCompraPagamento(Guid Id)
        {
            return serviceCompraPagamento.Excluir(Id);
        }

        #endregion Venda //=====================================================================

    }
}
