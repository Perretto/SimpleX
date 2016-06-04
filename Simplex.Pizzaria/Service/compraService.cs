using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;
using Simplex.Pizzaria.Context;
using Simplex.Pizzaria.Repository;
using Simplex.Pizzaria.Models;
using Simplex.Pizzaria.Service;

namespace Simplex.Pizzaria.Service
{

    public class compraService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;

        private Repository<compra> repositorycompra;

        public compraService()
        {
            context = new ContextPizzaria();
            repositorycompra = new Repository<compra>(context);
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
