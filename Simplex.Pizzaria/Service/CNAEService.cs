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

    public class CNAEService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<CNAE> repositoryCNAE;

        public CNAEService()
        {
            context = new ContextPizzaria();
            repositoryCNAE = new Repository<CNAE>(context);
        }

        public List<CNAE> Filtrar(CNAE CNAE)
        {
            return repositoryCNAE.ObterPorFiltros(b => (
                (CNAE.ID == Guid.Empty || b.ID == CNAE.ID) &&
                (CNAE.nome == null || b.nome.ToUpper().Contains(CNAE.nome)) &&
                (CNAE.codigo == null || b.codigo.ToUpper().Contains(CNAE.codigo))
                )).ToList();
        }

    }
}
