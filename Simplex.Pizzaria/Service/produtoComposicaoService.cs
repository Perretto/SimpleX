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

    public class produtoComposicaoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<produtoComposicao> repositoryprodutoComposicao;

        public produtoComposicaoService()
        {
            context = new ContextPizzaria();
            repositoryprodutoComposicao = new Repository<produtoComposicao>(context);
        }


        public List<produtoComposicao> Filtrar(produtoComposicao produtoComposicao)
        {
            return repositoryprodutoComposicao.ObterPorFiltros(b => (
                (produtoComposicao.ID == Guid.Empty || b.ID == produtoComposicao.ID) &&
                (produtoComposicao.produtoOrigemID == Guid.Empty || b.produtoOrigemID == produtoComposicao.produtoOrigemID) &&
                (produtoComposicao.produtoDestinoID == Guid.Empty || b.produtoDestinoID == produtoComposicao.produtoDestinoID) &&
                (produtoComposicao.quantidade == null || b.quantidade == produtoComposicao.quantidade) &&
                (produtoComposicao.empresaID == Guid.Empty || b.empresaID == produtoComposicao.empresaID)
                )).ToList();
        }

    }
}
