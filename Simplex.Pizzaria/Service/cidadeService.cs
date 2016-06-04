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

    public class cidadeService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<cidade> repositorycidade;

        public cidadeService()
        {
            context = new ContextPizzaria();
            repositorycidade = new Repository<cidade>(context);
        }

        public List<cidade> Filtrar(cidade cidade)
        {
            return repositorycidade.ObterPorFiltros(b => (
                (cidade.ID == Guid.Empty || b.ID == cidade.ID) &&
                (cidade.nome == null || b.nome.ToUpper().Contains(cidade.nome)) &&
                (cidade.codigo == null || b.codigo.ToUpper().Contains(cidade.codigo)) &&
                (cidade.empresaID == Guid.Empty || b.empresaID == cidade.empresaID)
                )).ToList();
        }

    }
}
