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

    public class CFOPService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<CFOP> repositoryCFOP;

        public CFOPService()
        {
            context = new ContextPizzaria();
            repositoryCFOP = new Repository<CFOP>(context);
        }

        public List<CFOP> Filtrar(CFOP CFOP)
        {
            return repositoryCFOP.ObterPorFiltros(b => (
                (CFOP.ID == Guid.Empty || b.ID == CFOP.ID) &&
                (CFOP.nome == null || b.nome.ToUpper().Contains(CFOP.nome)) &&
                (CFOP.codigo == null || b.codigo.ToUpper().Contains(CFOP.codigo))
                )).ToList();
        }

    }
}
