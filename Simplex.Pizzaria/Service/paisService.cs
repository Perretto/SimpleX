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

    public class paisService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<pais> repositorypais;

        public paisService()
        {
            context = new ContextPizzaria();
            repositorypais = new Repository<pais>(context);
        }
         


        public List<pais> Filtrar(pais pais)
        {
            return repositorypais.ObterPorFiltros(b => (
                (pais.ID == Guid.Empty || b.ID == pais.ID) &&
                (pais.nome == null || b.nome.ToUpper().Contains(pais.nome)) &&
                (pais.codigo == null || b.codigo.ToUpper().Contains(pais.codigo)) &&
                (pais.empresaID == Guid.Empty || b.empresaID == pais.empresaID)
                )).ToList();
        }

    }
}
