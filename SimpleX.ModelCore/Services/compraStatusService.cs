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

    public class compraStatusService : IDisposable
    {
        private Context context;
        private Repository<compraStatus> repositorycompraStatus;

        public compraStatusService()
        {
            context = new Context();
            repositorycompraStatus = new Repository<compraStatus>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<compraStatus> Listar()
        {
            return repositorycompraStatus.ObterTodos().ToList();
        }

        public compraStatus Consultar(Guid id)
        {
            return repositorycompraStatus.Obter(id);
        }

        public Result Salvar(compraStatus compraStatus)
        {
            Result retorno = new Result();

            try
            {
                if (compraStatus.ID == null)
                {
                    repositorycompraStatus.Adicionar(compraStatus);
                }
                else
                {
                    repositorycompraStatus.Alterar(compraStatus);
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

        public List<compraStatus> Filtrar(Expression<Func<compraStatus, bool>> filtro, Expression<Func<compraStatus, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorycompraStatus.Filtrar(filtro, campo, ordenacao).ToList();
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
                repositorycompraStatus.Remover(id);
                context.SaveChanges();
                retorno.Ok("status removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o status " + erro.Message);
            }
            return retorno;
        }

        public List<compraStatus> Filtrar(compraStatus compraStatus)
        {
            return repositorycompraStatus.ObterPorFiltros(b => (
                (compraStatus.ID == Guid.Empty || b.ID == compraStatus.ID) &&
                (compraStatus.nome == null || b.nome.ToUpper().Contains(compraStatus.nome)) &&
                (compraStatus.empresaID == Guid.Empty || b.empresaID == compraStatus.empresaID)
                )).ToList();
        }

    }
}
