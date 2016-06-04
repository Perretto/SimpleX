using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimpleX.ModelCore;
using Simplex.Pizzaria.Repository;
using System.Data.Entity;
using Simplex.Pizzaria.Context;
using SimpleX.ModelCore.Message;
using Simplex.Pizzaria.Models;

namespace Simplex.Pizzaria.Service
{

    public class vendaProdutoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<vendaProduto> repositoryVendaProduto;

        public vendaProdutoService()
        {
            context = new ContextPizzaria();
            repositoryVendaProduto = new Repository<vendaProduto>(context);
        }


        public List<vendaProduto> Filtrar(Simplex.Pizzaria.Models.vendaProduto vendaProduto)
        {
            return repositoryVendaProduto.ObterPorFiltros(b => (
                (vendaProduto.ID == Guid.Empty || b.ID == vendaProduto.ID) &&
                (vendaProduto.vendaID == Guid.Empty || b.vendaID == vendaProduto.vendaID) &&
                (vendaProduto.produtoID == Guid.Empty || b.produtoID == vendaProduto.produtoID) &&
                (vendaProduto.subProdutoID == Guid.Empty || b.subProdutoID == vendaProduto.subProdutoID) &&
                (vendaProduto.valorUnitario == 0 || b.valorUnitario == vendaProduto.valorUnitario) &&
                (vendaProduto.quantidade == 0 || b.quantidade == vendaProduto.quantidade) &&
                (vendaProduto.valorTotal == 0 || b.valorTotal == vendaProduto.valorTotal) &&
                (vendaProduto.empresaID == Guid.Empty || b.empresaID == vendaProduto.empresaID)
                )).ToList();
        }

    }
}
