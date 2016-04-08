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

    public class statusURAService : IDisposable
    {
        private Context context;
        private Repository<statusURA> repositorystatusURA;

        public statusURAService()
        {
            context = new Context();
            repositorystatusURA = new Repository<statusURA>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<statusURA> Listar()
        {
            return repositorystatusURA.ObterTodos().ToList();
        }

        public statusURA Consultar(Guid id)
        {
            return repositorystatusURA.Obter(id);
        }

        public Result Salvar(statusURA statusURA)
        {
            Result retorno = new Result();

            try
            {
                if (statusURA.ID == Guid.Empty)
                {
                    statusURA.ID = Guid.NewGuid();
                    repositorystatusURA.Adicionar(statusURA);
                }
                else
                {
                    repositorystatusURA.Alterar(statusURA);
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

        public List<statusURA> Filtrar(Expression<Func<statusURA, bool>> filtro, Expression<Func<statusURA, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorystatusURA.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir");
                return retorno;
            }
            try
            {
                repositorystatusURA.Remover(id);
                context.SaveChanges();
                retorno.Ok("Registro removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir" + erro.Message);
            }
            return retorno;
        }

        public List<statusURA> Filtrar(statusURA statusURA)
        {
            return repositorystatusURA.ObterPorFiltros(b => (
                (statusURA.ID == Guid.Empty || b.ID == statusURA.ID) &&
                (statusURA.texto == null || b.texto.ToUpper().Contains(statusURA.texto)) &&
                (statusURA.empresaID == Guid.Empty || b.empresaID == statusURA.empresaID)
                )).ToList();
        }

    }
}

