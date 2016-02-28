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

    public class compraService : IDisposable
    {
        private Context context;
        private Repository<compra> repositorycompra;

        public compraService()
        {
            context = new Context();
            repositorycompra = new Repository<compra>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<compra> Listar()
        {
            return repositorycompra.ObterTodos().ToList();
        }

        public compra Consultar(Guid id)
        {
            return repositorycompra.Obter(id);
        }

        public Result Salvar(compra compra)
        {
            Result retorno = new Result();

            try
            {
                if (compra.ID == null)
                {
                    repositorycompra.Adicionar(compra);
                }
                else
                {
                    repositorycompra.Alterar(compra);
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

        public List<compra> Filtrar(Expression<Func<compra, bool>> filtro, Expression<Func<compra, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositorycompra.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir a compra");
                return retorno;
            }
            try
            {
                repositorycompra.Remover(id);
                context.SaveChanges();
                retorno.Ok("compra removida com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir a compra " + erro.Message);
            }
            return retorno;
        }

        public List<compra> Filtrar(compra compra)
        {
            return repositorycompra.ObterPorFiltros(b => (
                (compra.ID == Guid.Empty || b.ID == compra.ID) &&
                (compra.numeroPedido == null || b.numeroPedido == compra.numeroPedido) &&
                (compra.valorTotal == null || b.valorTotal == compra.valorTotal) &&
                (compra.compraStatusID == Guid.Empty || b.compraStatusID == compra.compraStatusID) &&
                (compra.empresaID == Guid.Empty || b.empresaID == compra.empresaID) 
                )).ToList();
        }

    }
}
