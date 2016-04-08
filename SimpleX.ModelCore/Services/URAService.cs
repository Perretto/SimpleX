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

    public class URAService : IDisposable
    {
        private Context context;
        private Repository<URA> repositoryURA;

        public URAService()
        {
            context = new Context();
            repositoryURA = new Repository<URA>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<URA> Listar()
        {
            return repositoryURA.ObterTodos().ToList();
        }

        public URA Consultar(Guid id)
        {
            return repositoryURA.Obter(id);
        }

        public Result Salvar(URA URA)
        {
            Result retorno = new Result();

            try
            {
                if (URA.ID == Guid.Empty)
                {
                    URA.ID = Guid.NewGuid();
                    repositoryURA.Adicionar(URA);
                }
                else
                {
                    repositoryURA.Alterar(URA);
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

        public List<URA> Filtrar(Expression<Func<URA, bool>> filtro, Expression<Func<URA, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryURA.Filtrar(filtro, campo, ordenacao).ToList();
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
                repositoryURA.Remover(id);
                context.SaveChanges();
                retorno.Ok("Registro removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir" + erro.Message);
            }
            return retorno;
        }

        public List<URA> Filtrar(URA URA)
        {
            return repositoryURA.ObterPorFiltros(b => (
                (URA.ID == Guid.Empty || b.ID == URA.ID) &&
                (URA.texto == null || b.texto.ToUpper().Contains(URA.texto)) &&
                (URA.nivel == null || b.nivel == URA.nivel) &&
                (URA.statusURAID == Guid.Empty || b.statusURAID == URA.statusURAID) &&
                (URA.empresaID == Guid.Empty || b.empresaID == URA.empresaID)
                )).ToList();
        }

    }
}

