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

    public class CFOPService : IDisposable
    {
        private Context context;
        private Repository<CFOP> repositoryCFOP;

        public CFOPService()
        {
            context = new Context();
            repositoryCFOP = new Repository<CFOP>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<CFOP> Listar()
        {
            return repositoryCFOP.ObterTodos().ToList();
        }

        public CFOP Consultar(Guid id)
        {
            return repositoryCFOP.Obter(id);
        }

        public Result Salvar(CFOP CFOP)
        {
            Result retorno = new Result();

            try
            {
                if (CFOP.ID == Guid.Empty)
                {
                    CFOP.ID = Guid.NewGuid();
                    repositoryCFOP.Adicionar(CFOP);
                }
                else
                {
                    repositoryCFOP.Alterar(CFOP);
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

        public List<CFOP> Filtrar(Expression<Func<CFOP, bool>> filtro, Expression<Func<CFOP, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryCFOP.Filtrar(filtro, campo, ordenacao).ToList();
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
                repositoryCFOP.Remover(id);
                context.SaveChanges();
                retorno.Ok("CFOP removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o CFOP " + erro.Message);
            }
            return retorno;
        }

        public List<CFOP> Filtrar(CFOP CFOP)
        {
            return repositoryCFOP.ObterPorFiltros(b => (
                (CFOP.ID == Guid.Empty || b.ID == CFOP.ID) &&
                (CFOP.nome == null || b.nome.ToUpper().Contains(CFOP.nome)) &&
                (CFOP.codigo == null || b.codigo.ToUpper().Contains(CFOP.codigo))
                )).ToList();
        }

    }
}
