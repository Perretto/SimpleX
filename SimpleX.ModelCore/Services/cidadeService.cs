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

    public class cidadeService : IDisposable
    {
        private Context context;
        private Repository<cidade> repositorycidade;

        public cidadeService()
        {
            context = new Context();
            repositorycidade = new Repository<cidade>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<cidade> Listar()
        {
            return repositorycidade.ObterTodos().ToList();
        }

        public cidade Consultar(Guid id)
        {
            return repositorycidade.Obter(id);
        }

        public Result Salvar(cidade cidade)
        {
            Result retorno = new Result();

            try
            {
                if (cidade.ID == null)
                {
                    repositorycidade.Adicionar(cidade);
                }
                else
                {
                    repositorycidade.Alterar(cidade);
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

        public List<cidade> Filtrar(Expression<Func<cidade, bool>> filtro, Expression<Func<cidade, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorycidade.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a cidade");
                return retorno;
            }
            try
            {
                repositorycidade.Remover(id);
                context.SaveChanges();
                retorno.Ok("cidade removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir a cidade " + erro.Message);
            }
            return retorno;
        }

        public List<cidade> Filtrar(cidade cidade)
        {
            return repositorycidade.ObterPorFiltros(b => (
                (cidade.ID == Guid.Empty || b.ID == cidade.ID) &&
                (cidade.nome == null || b.nome.ToUpper().Contains(cidade.nome)) &&
                (cidade.codigo == null || b.codigo.ToUpper().Contains(cidade.codigo)) &&
                (cidade.empresaID == Guid.Empty || b.empresaID == cidade.empresaID)
                )).ToList();
        }

    }
}
