using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimpleX.ModelCore;
using System.Data.Entity;
using Simplex.Pizzaria.Context;
using Simplex.Pizzaria.Repository;
using Simplex.Pizzaria.Models;
using Simplex.Pizzaria.Service;

namespace Simplex.Pizzaria.Service
{

    public class produtoCategoriaService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<produtoCategoria> repositoryprodutoCategoria;

        public produtoCategoriaService()
        {
            context = new ContextPizzaria();
            repositoryprodutoCategoria = new Repository<produtoCategoria>(context);
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
