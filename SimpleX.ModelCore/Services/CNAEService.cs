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

    public class CNAEService : IDisposable
    {
        private Context context;
        private Repository<CNAE> repositoryCNAE;

        public CNAEService()
        {
            context = new Context();
            repositoryCNAE = new Repository<CNAE>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<CNAE> Listar()
        {
            return repositoryCNAE.ObterTodos().ToList();
        }

        public CNAE Consultar(Guid id)
        {
            return repositoryCNAE.Obter(id);
        }

        public Result Salvar(CNAE CNAE)
        {
            Result retorno = new Result();

            try
            {
                if (CNAE.ID == null)
                {
                    repositoryCNAE.Adicionar(CNAE);
                }
                else
                {
                    repositoryCNAE.Alterar(CNAE);
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

        public List<CNAE> Filtrar(Expression<Func<CNAE, bool>> filtro, Expression<Func<CNAE, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryCNAE.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o CNAE");
                return retorno;
            }
            try
            {
                repositoryCNAE.Remover(id);
                context.SaveChanges();
                retorno.Ok("CNAE removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o CNAE " + erro.Message);
            }
            return retorno;
        }

        public List<CNAE> Filtrar(CNAE CNAE)
        {
            return repositoryCNAE.ObterPorFiltros(b => (
                (CNAE.ID == Guid.Empty || b.ID == CNAE.ID) &&
                (CNAE.nome == null || b.nome.ToUpper().Contains(CNAE.nome)) &&
                (CNAE.codigo == null || b.codigo.ToUpper().Contains(CNAE.codigo))
                )).ToList();
        }

    }
}
