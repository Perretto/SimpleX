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

    public class service<T,U> where T : class where U : class
    {
        private U context;
        private genericRepository<T, U> repository;

        public service(T T, U Cont)
        {
            //context = new Context();
            repository = new genericRepository<T, U>(Cont);
        }

        //public void Dispose()
        //{
        //    if (context != null)
        //    {
        //        context.Dispose();
        //    }
        //}

        public List<T> Listar()
        {
            return repository.ObterTodos().ToList();
        }

        public T Consultar(Guid id)
        {
            return repository.Obter(id);
        }

        public Result Adicionar(T classe)
        {
            Result retorno = new Result();

            try
            {
                repository.Adicionar(classe);
                //context.SaveChanges();

                retorno.Ok("Registro adicionado com sucesso.");
                retorno.Sucesso = true;
            }
            catch (Exception erro)
            {
                retorno.Sucesso = false;
                retorno.Erro(erro.InnerException.Message);
            }

            return retorno;
        }

        public Result Alterar(T classe)
        {
            Result retorno = new Result();

            try
            {
                repository.Alterar(classe);
                //context.SaveChanges();

                retorno.Ok("Registro alterado com sucesso.");
                retorno.Sucesso = true;
            }
            catch (Exception erro)
            {
                retorno.Sucesso = false;
                retorno.Erro(erro.InnerException.Message);
            }

            return retorno;
        }

        public List<T> Filtrar(Expression<Func<T, bool>> filtro, Expression<Func<T, object>> campo = null, Ordenacao ordenacao = Ordenacao.Asc)
        {
            return repository.Filtrar(filtro, campo, ordenacao).ToList();
        }

        public Result Excluir(Guid id)
        {
            Result retorno = new Result();

            if (!retorno.Sucesso)
            {
                retorno.Erro("Encontrados erros ao excluir");
                return retorno;
            }
            try
            {
                repository.Remover(id);
                //context.SaveChanges();
                retorno.Ok("Removido com sucesso!");
            }
            catch (Exception erro)
            {
                retorno.Erro("Erros ao excluir - " + erro.Message);
            }
            return retorno;
        }
        
    }
}
