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

    public class produtoComposicaoService : IDisposable
    {
        private Context context;
        private Repository<produtoComposicao> repositoryprodutoComposicao;

        public produtoComposicaoService()
        {
            context = new Context();
            repositoryprodutoComposicao = new Repository<produtoComposicao>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<produtoComposicao> Listar()
        {
            return repositoryprodutoComposicao.ObterTodos().ToList();
        }

        public produtoComposicao Consultar(Guid id)
        {
            return repositoryprodutoComposicao.Obter(id);
        }

        public Result Salvar(produtoComposicao produtoComposicao)
        {
            Result retorno = new Result();

            try
            {
                if (produtoComposicao.ID == Guid.Empty)
                {
                    produtoComposicao.ID = Guid.NewGuid();

                    repositoryprodutoComposicao.Adicionar(produtoComposicao);
                }
                else
                {
                    repositoryprodutoComposicao.Alterar(produtoComposicao);
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

        public List<produtoComposicao> Filtrar(Expression<Func<produtoComposicao, bool>> filtro, Expression<Func<produtoComposicao, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryprodutoComposicao.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a composicao");
                return retorno;
            }
            try
            {
                repositoryprodutoComposicao.Remover(id);
                context.SaveChanges();
                retorno.Ok("Composicao removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir a composicao " + erro.Message);
            }
            return retorno;
        }

        public List<produtoComposicao> Filtrar(produtoComposicao produtoComposicao)
        {
            return repositoryprodutoComposicao.ObterPorFiltros(b => (
                (produtoComposicao.ID == Guid.Empty || b.ID == produtoComposicao.ID) &&
                (produtoComposicao.produtoOrigemID == Guid.Empty || b.produtoOrigemID == produtoComposicao.produtoOrigemID) &&
                (produtoComposicao.produtoDestinoID == Guid.Empty || b.produtoDestinoID == produtoComposicao.produtoDestinoID) &&
                (produtoComposicao.quantidade == null || b.quantidade == produtoComposicao.quantidade) &&
                (produtoComposicao.empresaID == Guid.Empty || b.empresaID == produtoComposicao.empresaID)
                )).ToList();
        }

    }
}
