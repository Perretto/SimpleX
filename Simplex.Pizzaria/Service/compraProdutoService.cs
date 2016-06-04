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

    public class compraProdutoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<compraProduto> repositorycompraProduto;

        public compraProdutoService()
        {
            context = new ContextPizzaria();
            repositorycompraProduto = new Repository<compraProduto>(context);
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
