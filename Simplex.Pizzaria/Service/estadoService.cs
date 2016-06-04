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

    public class estadoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<estado> repositoryestado;

        public estadoService()
        {
            context = new ContextPizzaria();
            repositoryestado = new Repository<estado>(context);
        }
        
        public List<estado> Filtrar(estado estado)
        {
            return repositoryestado.ObterPorFiltros(b => (
                (estado.ID == Guid.Empty || b.ID == estado.ID) &&
                (estado.nome == null || b.nome.ToUpper().Contains(estado.nome)) &&
                (estado.codigo == null || b.codigo.ToUpper().Contains(estado.codigo)) &&
                (estado.empresaID == Guid.Empty || b.empresaID == estado.empresaID)
                )).ToList();
        }

    }
}
