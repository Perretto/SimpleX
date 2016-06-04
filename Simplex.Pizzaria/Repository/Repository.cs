using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using SimpleX.Model;
using SimpleX.ModelCore;
using SimpleX.ModelCore.Contexts;
using System.Web;
using SimpleX.ModelCore.Repository;
using Simplex.Pizzaria.Context;


namespace Simplex.Pizzaria.Repository
{
    public enum Ordenacao
    {
        Asc,
        Desc
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        //private IContext context;


        private ContextPizzaria context;

        public Repository(ContextPizzaria context)
        {
            this.context = context;
        }

        public T Adicionar(T t)
        {
            T objetoNovo = setDados.Add(t);
            return objetoNovo;
        }

        private DbSet<T> setDados
        {
            get
            {
                return context.Set<T>();
            }
        }

        public void Alterar(T t)
        {
            var objetoAlterado = context.Entry(t);
            setDados.Attach(t);
            objetoAlterado.State = EntityState.Modified;
        }

        public void Remover(params object[] chaves)
        {
            T objetoEncontrado = setDados.Find(chaves);
            if (objetoEncontrado != null)
            {
                setDados.Remove(objetoEncontrado);
            }
        }

        public void Remover(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            foreach (T item in ObterPorFiltros(predicado))
            {
                Remover(item);
            }
        }


        public void Remover(T t)
        {
            setDados.Remove(t);
        }


        public int Contagem()
        {
            return setDados.Count();
        }

        public int Contagem(System.Linq.Expressions.Expression<Func<T, bool>> predicado)
        {
            return setDados.Count(predicado);
        }


        public bool Contem(Expression<Func<T, bool>> predicado)
        {
            return setDados.Count(predicado) > 0;
        }


        public T Obter(params object[] chaves)
        {
            return setDados.Find(chaves);
        }

        public IQueryable<T> ObterTodos()
        {
            return setDados.AsQueryable();
        }


        public IQueryable<T> ObterPorFiltros(Expression<Func<T, bool>> predicado)
        {
            return setDados.Where(predicado).AsQueryable();
        }


        public IQueryable<T> ObterPorFiltros(Expression<Func<T, bool>> predicado, out int totalPaginas, int tamanho = 10, int pagina = 1)
        {
            var novoSetDados = predicado == null ? ObterTodos() : ObterPorFiltros(predicado);
            int qtdPular = tamanho * (pagina - 1);

            novoSetDados = qtdPular == 0 ? novoSetDados.Take(tamanho) : novoSetDados.Skip(qtdPular).Take(tamanho);
            totalPaginas = novoSetDados.Count();

            return novoSetDados.AsQueryable();
        }
        public IQueryable<T> Filtrar(Expression<Func<T, bool>> filtro, Expression<Func<T, object>> campo = null, SimpleX.ModelCore.Repository.Ordenacao ordenacao = SimpleX.ModelCore.Repository.Ordenacao.Asc)
        {
            var objSet = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<T>();
            var objQuery = (ObjectQuery<T>)objSet;
            var resultado = objQuery.Where(filtro == null ? t => 1 == 1 : filtro);

            if (campo != null)
            {
                if (ordenacao.Equals(Ordenacao.Asc))
                {
                    resultado = resultado.OrderBy(campo);
                }
                else
                {
                    resultado = resultado.OrderByDescending(campo);
                }
            }
            return resultado;
        }

    }
}
