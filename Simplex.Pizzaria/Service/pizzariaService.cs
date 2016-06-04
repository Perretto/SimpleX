using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimpleX.ModelCore;
using Simplex.Pizzaria.Models;
using System.Data.Entity;
using Simplex.Pizzaria.Context;
using Simplex.Pizzaria.Repository;

namespace Simplex.Pizzaria.Service
{
    public class pizzariaService <T> where T : class  
    {
        private ContextPizzaria context;
        private Repository<T> repositorycidade;
      
        public pizzariaService()
        {
            context = new ContextPizzaria();
            repositorycidade = new Repository<T>(context);
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public List<T> Listar()
        {
            return repositorycidade.ObterTodos().ToList();
        }

        public T Consultar(Guid id)
        {
            return repositorycidade.Obter(id);
        }

        public Result Salvar(T objeto)
        {
            Result retorno = new Result();

           
                repositorycidade.Adicionar(objeto);
                context.SaveChanges();

                retorno.Ok("Cadastro realizado com sucesso.");
          

            return retorno;
        }

        public Result Alterar(T objeto)
        {
            Result retorno = new Result();


            repositorycidade.Alterar(objeto);
            context.SaveChanges();

            retorno.Ok("Cadastro alterado com sucesso.");


            return retorno;
        }

        public List<T> Filtrar(Expression<Func<T, bool>> filtro, Expression<Func<T, object>> campo = null, SimpleX.ModelCore.Repository.Ordenacao ordenacao = SimpleX.ModelCore.Repository.Ordenacao.Asc)
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

       

    }
}
