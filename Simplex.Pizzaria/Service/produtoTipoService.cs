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

    public class produtoTipoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<produtoTipo> repositoryprodutoTipo;

        public produtoTipoService()
        {
            context = new ContextPizzaria();
            repositoryprodutoTipo = new Repository<produtoTipo>(context);
        }

        public List<produtoTipo> Filtrar(produtoTipo produtoTipo)
        {
            return repositoryprodutoTipo.ObterPorFiltros(b => (
                (produtoTipo.ID == Guid.Empty || b.ID == produtoTipo.ID) &&
                (produtoTipo.nome == null || b.nome.ToUpper().Contains(produtoTipo.nome)) &&
                (produtoTipo.empresaID == Guid.Empty || b.empresaID == produtoTipo.empresaID)
                )).ToList();
        }

    }
}
