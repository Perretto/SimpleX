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
using SimpleX.Core;
using SimpleX.ModelCore.Contexts;

namespace SimpleX.ModelCore.Services
{

    public class formaPagamentoService : IDisposable
    {
        private Context context;
        private Repository<formaPagamento> repositoryformaPagamento;

        public formaPagamentoService()
        {
            context = new Context();
            repositoryformaPagamento = new Repository<formaPagamento>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<formaPagamento> Listar()
        {
            return repositoryformaPagamento.ObterTodos().ToList();
        }

        public formaPagamento Consultar(Guid id)
        {
            return repositoryformaPagamento.Obter(id);
        }

        public Result Salvar(formaPagamento formaPagamento)
        {
            Result retorno = new Result();

            try
            {
                if (formaPagamento.ID == null)
                {
                    repositoryformaPagamento.Adicionar(formaPagamento);
                }
                else
                {
                    repositoryformaPagamento.Alterar(formaPagamento);
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

        public List<formaPagamento> Filtrar(Expression<Func<formaPagamento, bool>> filtro, Expression<Func<formaPagamento, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryformaPagamento.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a forma de Pagamento");
                return retorno;
            }
            try
            {
                repositoryformaPagamento.Remover(id);
                context.SaveChanges();
                retorno.Ok("forma de Pagamento removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir a forma de Pagamento " + erro.Message);
            }
            return retorno;
        }

        public List<formaPagamento> Filtrar(formaPagamento formaPagamento)
        {
            return repositoryformaPagamento.ObterPorFiltros(b => (
                (formaPagamento.ID == Guid.Empty || b.ID == formaPagamento.ID) &&
                (formaPagamento.nome == null || b.nome.ToUpper().Contains(formaPagamento.nome)) &&
                (formaPagamento.empresaID == Guid.Empty || b.empresaID == formaPagamento.empresaID)
                )).ToList();
        }

    }
}
