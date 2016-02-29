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

    public class compraPagamentoService : IDisposable
    {
        private Context context;
        private Repository<compraPagamento> repositorycompraPagamento;

        public compraPagamentoService()
        {
            context = new Context();
            repositorycompraPagamento = new Repository<compraPagamento>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<compraPagamento> Listar()
        {
            return repositorycompraPagamento.ObterTodos().ToList();
        }

        public compraPagamento Consultar(Guid id)
        {
            return repositorycompraPagamento.Obter(id);
        }

        public Result Salvar(compraPagamento compraPagamento)
        {
            Result retorno = new Result();

            try
            {
                if (compraPagamento.ID == null)
                {
                    repositorycompraPagamento.Adicionar(compraPagamento);
                }
                else
                {
                    repositorycompraPagamento.Alterar(compraPagamento);
                }

                context.SaveChanges();

                retorno.Ok("Cadastro realizado com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }

            return retorno;
        }

        public List<compraPagamento> Filtrar(Expression<Func<compraPagamento, bool>> filtro, Expression<Func<compraPagamento, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorycompraPagamento.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o Pagamento");
                return retorno;
            }
            try
            {
                repositorycompraPagamento.Remover(id);
                context.SaveChanges();
                retorno.Ok("Pagamento removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o pagamento " + erro.Message);
            }
            return retorno;
        }

        public List<compraPagamento> Filtrar(compraPagamento compraPagamento)
        {
            return repositorycompraPagamento.ObterPorFiltros(b => (
                (compraPagamento.ID == Guid.Empty || b.ID == compraPagamento.ID) &&
                (compraPagamento.compraID == Guid.Empty || b.compraID == compraPagamento.compraID) &&
                (compraPagamento.formaPagamentoID == Guid.Empty || b.formaPagamentoID == compraPagamento.formaPagamentoID) &&
                (compraPagamento.empresaID == Guid.Empty || b.empresaID == compraPagamento.empresaID)
                )).ToList();
        }

    }
}
