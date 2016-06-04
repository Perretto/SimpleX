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

    public class vendaStatusService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<vendaStatus> repositoryvendaStatus;

        public vendaStatusService()
        {
            context = new ContextPizzaria();
            repositoryvendaStatus = new Repository<vendaStatus>(context);
        }

        public List<vendaStatus> Filtrar(vendaStatus vendaStatus)
        {
            return repositoryvendaStatus.ObterPorFiltros(b => (
                (vendaStatus.ID == Guid.Empty || b.ID == vendaStatus.ID) &&
                (vendaStatus.nome == null || b.nome.ToUpper().Contains(vendaStatus.nome)) &&
                (vendaStatus.empresaID == Guid.Empty || b.empresaID == vendaStatus.empresaID)
                )).ToList();
        }

    }
}
