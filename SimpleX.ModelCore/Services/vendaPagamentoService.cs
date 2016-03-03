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

    public class vendaPagamentoService : IDisposable
    {
        private Context context;
        private Repository<vendaPagamento> repositoryvendaPagamento;

        public vendaPagamentoService()
        {
            context = new Context();
            repositoryvendaPagamento = new Repository<vendaPagamento>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<vendaPagamento> Listar()
        {
            return repositoryvendaPagamento.ObterTodos().ToList();
        }

        public vendaPagamento Consultar(Guid id)
        {
            return repositoryvendaPagamento.Obter(id);
        }

        public Result Salvar(vendaPagamento vendaPagamento)
        {
            Result retorno = new Result();

            try
            {
                if (vendaPagamento.ID == Guid.Empty)
                {
                    vendaPagamento.ID = Guid.NewGuid();
                    repositoryvendaPagamento.Adicionar(vendaPagamento);
                }
                else
                {
                    repositoryvendaPagamento.Alterar(vendaPagamento);
                }

                context.SaveChanges();

                retorno.Ok("Pagamento salvo com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }

            return retorno;
        }

        public List<vendaPagamento> Filtrar(Expression<Func<vendaPagamento, bool>> filtro, Expression<Func<vendaPagamento, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryvendaPagamento.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o pagamento");
                return retorno;
            }
            try
            {
                repositoryvendaPagamento.Remover(id);
                context.SaveChanges();
                retorno.Ok("Pagamento removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o pagamento " + erro.Message);
            }
            return retorno;
        }

        public List<vendaPagamento> Filtrar(vendaPagamento vendaPagamento)
        {
            return repositoryvendaPagamento.ObterPorFiltros(b => (
                (vendaPagamento.ID == Guid.Empty || b.ID == vendaPagamento.ID) &&
                (vendaPagamento.vendaID == Guid.Empty || b.vendaID == vendaPagamento.vendaID) &&
                (vendaPagamento.formaPagamentoID == Guid.Empty || b.formaPagamentoID == vendaPagamento.formaPagamentoID) &&
                (vendaPagamento.empresaID == Guid.Empty || b.empresaID == vendaPagamento.empresaID)
                )).ToList();
        }

    }
}
