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

    public class vendaProdutoService : IDisposable
    {
        private Context context;
        private Repository<vendaProduto> repositoryvendaProduto;

        public vendaProdutoService()
        {
            context = new Context();
            repositoryvendaProduto = new Repository<vendaProduto>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<vendaProduto> Listar()
        {
            return repositoryvendaProduto.ObterTodos().ToList();
        }

        public vendaProduto Consultar(Guid id)
        {
            return repositoryvendaProduto.Obter(id);
        }

        public Result Salvar(vendaProduto vendaProduto)
        {
            Result retorno = new Result();

            try
            {
                if (vendaProduto.ID == Guid.Empty)
                {
                    vendaProduto.ID = Guid.NewGuid();
                    repositoryvendaProduto.Adicionar(vendaProduto);
                }
                else
                {
                    repositoryvendaProduto.Alterar(vendaProduto);
                }

                context.SaveChanges();

                retorno.Ok("Produto realizado com sucesso.");
            }
            catch (Exception erro)
            {
                retorno.Erro(erro.Message);
            }

            return retorno;
        }

        public List<vendaProduto> Filtrar(Expression<Func<vendaProduto, bool>> filtro, Expression<Func<vendaProduto, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryvendaProduto.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o produto na venda");
                return retorno;
            }
            try
            {
                repositoryvendaProduto.Remover(id);
                context.SaveChanges();
                retorno.Ok("Produto da venda removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o produto na venda " + erro.Message);
            }
            return retorno;
        }

        public List<vendaProduto> Filtrar(vendaProduto vendaProduto)
        {
            return repositoryvendaProduto.ObterPorFiltros(b => (
                (vendaProduto.ID == Guid.Empty || b.ID == vendaProduto.ID) &&
                (vendaProduto.vendaID == Guid.Empty || b.vendaID == vendaProduto.vendaID) &&
                (vendaProduto.produtoID == Guid.Empty || b.produtoID == vendaProduto.produtoID) &&
                (vendaProduto.valorUnitario == null || b.valorUnitario == vendaProduto.valorUnitario) &&
                (vendaProduto.quantidade == null || b.quantidade == vendaProduto.quantidade) &&
                (vendaProduto.valorTotal == null || b.valorTotal == vendaProduto.valorTotal) &&
                (vendaProduto.empresaID == Guid.Empty || b.empresaID == vendaProduto.empresaID)
                )).ToList();
        }

    }
}
