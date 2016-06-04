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

    public class produtoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<produto> repositoryproduto;

        public produtoService()
        {
            context = new ContextPizzaria();
            repositoryproduto = new Repository<produto>(context);
        }

        public List<produto> Filtrar(produto produto)
        {
            return repositoryproduto.ObterPorFiltros(b => (
                (produto.ID == Guid.Empty || b.ID == produto.ID) &&
                (produto.nome == null || b.nome.ToUpper().Contains(produto.nome)) &&
                (produto.codigo == null || b.codigo.ToUpper().Contains(produto.codigo)) &&
                (produto.produtoCategoriaID == Guid.Empty || b.produtoCategoriaID == produto.produtoCategoriaID) &&
                (produto.valorProduto == 0 || b.valorProduto == produto.valorProduto) &&
                (produto.produtoTipoID == Guid.Empty || b.produtoTipoID == produto.produtoTipoID) &&
                (produto.empresaID == Guid.Empty || b.empresaID == produto.empresaID)
                )).ToList();
        }

    }
}
