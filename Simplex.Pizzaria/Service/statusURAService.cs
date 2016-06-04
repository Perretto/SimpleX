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

    public class statusURAService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<statusURA> repositorystatusURA;

        public statusURAService()
        {
            context = new ContextPizzaria();
            repositorystatusURA = new Repository<statusURA>(context);
        }

        public List<statusURA> Filtrar(statusURA statusURA)
        {
            return repositorystatusURA.ObterPorFiltros(b => (
                (statusURA.ID == Guid.Empty || b.ID == statusURA.ID) &&
                (statusURA.texto == null || b.texto.ToUpper().Contains(statusURA.texto)) &&
                (statusURA.empresaID == Guid.Empty || b.empresaID == statusURA.empresaID)
                )).ToList();
        }

    }
}
