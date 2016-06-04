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

    public class compraStatusService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<compraStatus> repositorycompraStatus;

        public compraStatusService()
        {
            context = new ContextPizzaria();
            repositorycompraStatus = new Repository<compraStatus>(context);
        }
        
        public List<compraStatus> Filtrar(compraStatus compraStatus)
        {
            return repositorycompraStatus.ObterPorFiltros(b => (
                (compraStatus.ID == Guid.Empty || b.ID == compraStatus.ID) &&
                (compraStatus.nome == null || b.nome.ToUpper().Contains(compraStatus.nome)) &&
                (compraStatus.empresaID == Guid.Empty || b.empresaID == compraStatus.empresaID)
                )).ToList();
        }

    }
}
