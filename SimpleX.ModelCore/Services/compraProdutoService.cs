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

    public class compraProdutoService : IDisposable
    {
        private Context context;
        private Repository<compraProduto> repositorycompraProduto;

        public compraProdutoService()
        {
            context = new Context();
            repositorycompraProduto = new Repository<compraProduto>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<compraProduto> Listar()
        {
            return repositorycompraProduto.ObterTodos().ToList();
        }

        public compraProduto Consultar(Guid id)
        {
            return repositorycompraProduto.Obter(id);
        }

        public Result Salvar(compraProduto compraProduto)
        {
            Result retorno = new Result();

            try
            {
                if (compraProduto.ID == null)
                {
                    repositorycompraProduto.Adicionar(compraProduto);
                }
                else
                {
                    repositorycompraProduto.Alterar(compraProduto);
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

        public List<compraProduto> Filtrar(Expression<Func<compraProduto, bool>> filtro, Expression<Func<compraProduto, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorycompraProduto.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o produto");
                return retorno;
            }
            try
            {
                repositorycompraProduto.Remover(id);
                context.SaveChanges();
                retorno.Ok("produto removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o produto " + erro.Message);
            }
            return retorno;
        }

        public List<compraProduto> Filtrar(compraProduto compraProduto)
        {
            return repositorycompraProduto.ObterPorFiltros(b => (
                (compraProduto.ID == Guid.Empty || b.ID == compraProduto.ID) &&
                (compraProduto.compraID == Guid.Empty || b.compraID == compraProduto.compraID) &&
                (compraProduto.produtoID == Guid.Empty || b.produtoID == compraProduto.produtoID) &&
                (compraProduto.valorUnitario == null || b.valorUnitario == compraProduto.valorUnitario) &&
                (compraProduto.quantidade == null || b.quantidade == compraProduto.quantidade) &&
                (compraProduto.valorTotal == null || b.valorTotal == compraProduto.valorTotal) &&
                (compraProduto.empresaID == Guid.Empty || b.empresaID == compraProduto.empresaID)
                )).ToList();
        }

    }
}
