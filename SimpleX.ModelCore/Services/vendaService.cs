using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimpleX.ModelCore;
using SimpleX.ModelCore.Repository;
using SimpleX.Model;
using System.Data.Entity;
using SimpleX.ModelCore.Contexts;

namespace SimpleX.ModelCore.Services
{

    public class vendaService : IDisposable
    {
        private Context context;
        private Repository<venda> repositoryvenda;

        public vendaService()
        {
            context = new Context();
            repositoryvenda = new Repository<venda>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<venda> Listar()
        {
            return repositoryvenda.ObterTodos().ToList();
        }

        public venda Consultar(Guid id)
        {
            return repositoryvenda.Obter(id);
        }

        public Result Salvar(venda venda)
        {
            Result retorno = new Result();

            try
            {
                if (venda.ID == Guid.Empty)
                {
                    venda.ID = Guid.NewGuid();
                    repositoryvenda.Adicionar(venda);
                }
                else
                {
                    repositoryvenda.Alterar(venda);
                }

                context.SaveChanges();

                retorno.Ok("Venda realizada com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }

            return retorno;
        }

        public List<venda> Filtrar(Expression<Func<venda, bool>> filtro, Expression<Func<venda, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryvenda.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a venda");
                return retorno;
            }
            try
            {
                repositoryvenda.Remover(id);
                context.SaveChanges();
                retorno.Ok("venda removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir a venda " + erro.Message);
            }
            return retorno;
        }

        public int BuscarUltimoPedido(Guid idEmpresa)
        {
            int numeroPedido = 0;

            venda venda = new venda();
            venda.empresaID = idEmpresa;

            //List<venda> lstvenda = repositoryvenda.ObterPorFiltros(b => (
            //    (venda.ID == Guid.Empty || b.ID == venda.ID) &&
            //    (venda.numeroPedido == 0 || b.numeroPedido == venda.numeroPedido) &&
            //    (venda.clienteID == Guid.Empty || b.clienteID == venda.clienteID) &&
            //    (venda.valorTotal == 0 || b.valorTotal == venda.valorTotal) &&
            //    (venda.vendaStatusID == Guid.Empty || b.vendaStatusID == venda.vendaStatusID) &&
            //    (venda.empresaID == Guid.Empty || b.empresaID == venda.empresaID)
            //    )).ToList();

            List<venda> lstvenda = repositoryvenda.ObterPorFiltros(b => (
                (venda.empresaID == Guid.Empty || b.empresaID == venda.empresaID)
                )).ToList();

            lstvenda = lstvenda.OrderByDescending(v=> v.numeroPedido).ToList();

            if (lstvenda.Count > 0)
            {
                numeroPedido = lstvenda[0].numeroPedido;
            }
            return numeroPedido;
        }

        public List<venda> Filtrar(venda venda)
        {
            return repositoryvenda.ObterPorFiltros(b => (
                (venda.ID == Guid.Empty || b.ID == venda.ID) &&
                (venda.numeroPedido == 0 || b.numeroPedido == venda.numeroPedido) &&
                (venda.clienteID == Guid.Empty || b.clienteID == venda.clienteID) &&
                (venda.valorTotal == 0 || b.valorTotal == venda.valorTotal) &&
                (venda.vendaStatusID == Guid.Empty || b.vendaStatusID == venda.vendaStatusID) &&
                (venda.empresaID == Guid.Empty || b.empresaID == venda.empresaID)
                )).ToList();
        }
    }
}
