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

    public class produtoCategoriaService : IDisposable
    {
        private Context context;
        private Repository<produtoCategoria> repositoryprodutoCategoria;

        public produtoCategoriaService()
        {
            context = new Context();
            repositoryprodutoCategoria = new Repository<produtoCategoria>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<produtoCategoria> Listar()
        {
            return repositoryprodutoCategoria.ObterTodos().ToList();
        }

        public produtoCategoria Consultar(Guid id)
        {
            return repositoryprodutoCategoria.Obter(id);
        }

        public Result Salvar(produtoCategoria produtoCategoria)
        {
            Result retorno = new Result();

            try
            {
                if (produtoCategoria.ID == Guid.Empty)
                {
                    produtoCategoria.ID = Guid.NewGuid();
                    repositoryprodutoCategoria.Adicionar(produtoCategoria);
                }
                else
                {
                    repositoryprodutoCategoria.Alterar(produtoCategoria);
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

        public List<produtoCategoria> Filtrar(Expression<Func<produtoCategoria, bool>> filtro, Expression<Func<produtoCategoria, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryprodutoCategoria.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a categoria");
                return retorno;
            }
            try
            {
                repositoryprodutoCategoria.Remover(id);
                context.SaveChanges();
                retorno.Ok("Categoria removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir a categoria " + erro.Message);
            }
            return retorno;
        }

        public List<produtoCategoria> Filtrar(produtoCategoria produtoCategoria)
        {
            return repositoryprodutoCategoria.ObterPorFiltros(b => (
                (produtoCategoria.ID == Guid.Empty || b.ID == produtoCategoria.ID) &&
                (produtoCategoria.nome == null || b.nome.ToUpper().Contains(produtoCategoria.nome)) &&
                (produtoCategoria.empresaID == Guid.Empty || b.empresaID == produtoCategoria.empresaID)
                )).ToList();
        }

    }
}
