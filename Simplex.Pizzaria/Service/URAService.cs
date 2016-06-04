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

    public class URAService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<URA> repositoryURA;

        public URAService()
        {
            context = new ContextPizzaria();
            repositoryURA = new Repository<URA>(context);
        }

        public List<URA> Filtrar(URA URA)
        {
            return repositoryURA.ObterPorFiltros(b => (
                (URA.ID == Guid.Empty || b.ID == URA.ID) &&
                (URA.texto == null || b.texto.ToUpper().Contains(URA.texto)) &&
                (URA.nivel == null || b.nivel == URA.nivel) &&
                (URA.statusURAID == Guid.Empty || b.statusURAID == URA.statusURAID) &&
                (URA.empresaID == Guid.Empty || b.empresaID == URA.empresaID)
                )).ToList();
        }

    }
}
