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

    public class systemMessageService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<systemMessage> repositorysystemMessage;

        public systemMessageService()
        {
            context = new ContextPizzaria();
            repositorysystemMessage = new Repository<systemMessage>(context);
        }

        public List<systemMessage> Filtrar(systemMessage message)
        {
            return repositorysystemMessage.ObterPorFiltros(b => (
                (message.ID == Guid.Empty || b.ID == message.ID) &&
                (message.internalNumber == null || b.internalNumber == message.internalNumber) &&
                (message.externalNumber == null || b.externalNumber == message.externalNumber) &&
                (message.type == null || b.type == message.type) &&
                (message.description == null || b.description.ToUpper().Contains(message.description))
                )).ToList();
        }

    }
}
