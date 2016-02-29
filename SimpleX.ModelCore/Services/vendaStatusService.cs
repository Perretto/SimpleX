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

    public class vendaStatusService : IDisposable
    {
        private Context context;
        private Repository<vendaStatus> repositoryvendaStatus;

        public vendaStatusService()
        {
            context = new Context();
            repositoryvendaStatus = new Repository<vendaStatus>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<vendaStatus> Listar()
        {
            return repositoryvendaStatus.ObterTodos().ToList();
        }

        public vendaStatus Consultar(Guid id)
        {
            return repositoryvendaStatus.Obter(id);
        }

        public Result Salvar(vendaStatus vendaStatus)
        {
            Result retorno = new Result();

            try
            {
                if (vendaStatus.ID == null)
                {
                    repositoryvendaStatus.Adicionar(vendaStatus);
                }
                else
                {
                    repositoryvendaStatus.Alterar(vendaStatus);
                }

                context.SaveChanges();

                retorno.Ok("Status realizado com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }

            return retorno;
        }

        public List<vendaStatus> Filtrar(Expression<Func<vendaStatus, bool>> filtro, Expression<Func<vendaStatus, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryvendaStatus.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o status");
                return retorno;
            }
            try
            {
                repositoryvendaStatus.Remover(id);
                context.SaveChanges();
                retorno.Ok("Status removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o status " + erro.Message);
            }
            return retorno;
        }

        public List<vendaStatus> Filtrar(vendaStatus vendaStatus)
        {
            return repositoryvendaStatus.ObterPorFiltros(b => (
                (vendaStatus.ID == Guid.Empty || b.ID == vendaStatus.ID) &&
                (vendaStatus.nome == null || b.nome.ToUpper().Contains(vendaStatus.nome)) &&
                (vendaStatus.empresaID == Guid.Empty || b.empresaID == vendaStatus.empresaID)
                )).ToList();
        }

    }
}
