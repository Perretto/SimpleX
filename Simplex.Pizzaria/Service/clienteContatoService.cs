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

    public class clienteContatoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;

        private Repository<clienteContato> repositoryclienteContato;

        public clienteContatoService()
        {
            context = new ContextPizzaria();
            repositoryclienteContato = new Repository<clienteContato>(context);
        }

        public List<clienteContato> Filtrar(clienteContato clienteContato)
        {
            return repositoryclienteContato.ObterPorFiltros(b => (
                (clienteContato.ID == Guid.Empty || b.ID == clienteContato.ID) &&
                (clienteContato.nomeContato == null || b.nomeContato.ToUpper().Contains(clienteContato.nomeContato)) &&
                (clienteContato.telefoneContato == null || b.telefoneContato.ToUpper().Contains(clienteContato.telefoneContato)) &&
                (clienteContato.emailContato == null || b.emailContato.ToUpper().Contains(clienteContato.emailContato)) &&
                (clienteContato.clienteID == Guid.Empty || b.clienteID == clienteContato.clienteID) &&
                (clienteContato.empresaID == Guid.Empty || b.empresaID == clienteContato.empresaID)
                )).ToList();
        }

    }
}
