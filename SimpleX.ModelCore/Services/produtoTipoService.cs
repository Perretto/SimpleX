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

    public class produtoTipoService : IDisposable
    {
        private Context context;
        private Repository<produtoTipo> repositoryprodutoTipo;

        public produtoTipoService()
        {
            context = new Context();
            repositoryprodutoTipo = new Repository<produtoTipo>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<produtoTipo> Listar()
        {
            return repositoryprodutoTipo.ObterTodos().ToList();
        }

        public produtoTipo Consultar(Guid id)
        {
            return repositoryprodutoTipo.Obter(id);
        }

        public Result Salvar(produtoTipo produtoTipo)
        {
            Result retorno = new Result();

            try
            {
                if (produtoTipo.ID == Guid.Empty)
                {
                    produtoTipo.ID = Guid.NewGuid();
                    repositoryprodutoTipo.Adicionar(produtoTipo);
                }
                else
                {
                    repositoryprodutoTipo.Alterar(produtoTipo);
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

        public List<produtoTipo> Filtrar(Expression<Func<produtoTipo, bool>> filtro, Expression<Func<produtoTipo, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repositoryprodutoTipo.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir o tipo de produto");
                return retorno;
            }
            try
            {
                repositoryprodutoTipo.Remover(id);
                context.SaveChanges();
                retorno.Ok("Tipo de produto removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir o tipo de produto " + erro.Message);
            }
            return retorno;
        }

        public List<produtoTipo> Filtrar(produtoTipo produtoTipo)
        {
            return repositoryprodutoTipo.ObterPorFiltros(b => (
                (produtoTipo.ID == Guid.Empty || b.ID == produtoTipo.ID) &&
                (produtoTipo.nome == null || b.nome.ToUpper().Contains(produtoTipo.nome)) &&
                (produtoTipo.empresaID == Guid.Empty || b.empresaID == produtoTipo.empresaID)
                )).ToList();
        }

    }
}
