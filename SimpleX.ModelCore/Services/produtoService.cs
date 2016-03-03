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

    public class produtoService : IDisposable
    {
        private Context context;
        private Repository<produto> repositoryproduto;

        public produtoService()
        {
            context = new Context();
            repositoryproduto = new Repository<produto>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<produto> Listar()
        {
            return repositoryproduto.ObterTodos().ToList();
        }

        public produto Consultar(Guid id)
        {
            return repositoryproduto.Obter(id);
        }

        public Result Salvar(produto produto)
        {
            Result retorno = new Result();

            try
            {
                if (produto.ID == null)
                {
                    repositoryproduto.Adicionar(produto);
                }
                else
                {
                    repositoryproduto.Alterar(produto);
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

        public List<produto> Filtrar(Expression<Func<produto, bool>> filtro, Expression<Func<produto, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryproduto.Filtrar(filtro, campo, ordenacao).ToList();
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
                repositoryproduto.Remover(id);
                context.SaveChanges();
                retorno.Ok("produto removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o produto " + erro.Message);
            }
            return retorno;
        }

        public List<produto> Filtrar(produto produto)
        {
            return repositoryproduto.ObterPorFiltros(b => (
                (produto.ID == Guid.Empty || b.ID == produto.ID) &&
                (produto.nome == null || b.nome.ToUpper().Contains(produto.nome)) &&
                (produto.codigo == null || b.codigo.ToUpper().Contains(produto.codigo)) &&                
                (produto.produtoCategoriaID == Guid.Empty || b.produtoCategoriaID == produto.produtoCategoriaID) &&
                (produto.valorProduto == 0 || b.valorProduto == produto.valorProduto) &&
                (produto.produtoTipoID == Guid.Empty || b.produtoTipoID == produto.produtoTipoID) &&
                (produto.empresaID == Guid.Empty || b.empresaID == produto.empresaID)
                )).ToList();
        }

    }
}
