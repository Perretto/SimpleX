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
    public class vendaService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<venda> repositoryvenda;

        public vendaService()
        {
            context = new ContextPizzaria();
            repositoryvenda = new Repository<venda>(context);
        }

        public List<venda> Filtrar(venda venda)
        {
            return repositoryvenda.ObterPorFiltros(b => (
                (venda.ID == Guid.Empty || b.ID == venda.ID) &&
                (venda.numeroPedido == 0 || b.numeroPedido == venda.numeroPedido) &&
                (venda.clienteID == Guid.Empty || b.clienteID == venda.clienteID) &&
                (venda.valorTotal == 0 || b.valorTotal == venda.valorTotal) &&
                (venda.vendaStatusID == Guid.Empty || b.vendaStatusID == venda.vendaStatusID) &&
                (venda.empresaID == Guid.Empty || b.empresaID == venda.empresaID)
                )).ToList();
        }

    }
}
