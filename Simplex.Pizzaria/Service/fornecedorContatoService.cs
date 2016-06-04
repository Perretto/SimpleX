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

    public class fornecedorContatoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;

        private Repository<fornecedorContato> repositoryfornecedorContato;

        public fornecedorContatoService()
        {
            context = new ContextPizzaria();
            repositoryfornecedorContato = new Repository<fornecedorContato>(context);
        }
              
        public List<fornecedorContato> Filtrar(fornecedorContato fornecedorContato)
        {
            return repositoryfornecedorContato.ObterPorFiltros(b => (
                (fornecedorContato.ID == Guid.Empty || b.ID == fornecedorContato.ID) &&
                (fornecedorContato.nomeContato == null || b.nomeContato.ToUpper().Contains(fornecedorContato.nomeContato)) &&
                (fornecedorContato.telefoneContato == null || b.telefoneContato.ToUpper().Contains(fornecedorContato.telefoneContato)) &&
                (fornecedorContato.emailContato == null || b.emailContato.ToUpper().Contains(fornecedorContato.emailContato)) &&
                (fornecedorContato.fornecedorID == Guid.Empty || b.fornecedorID == fornecedorContato.fornecedorID) &&
                (fornecedorContato.empresaID == Guid.Empty || b.empresaID == fornecedorContato.empresaID)
                )).ToList();
        }

    }
}
