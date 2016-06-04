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

    public class vendaPagamentoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<vendaPagamento> repositoryvendaPagamento;

        public vendaPagamentoService()
        {
            context = new ContextPizzaria();
            repositoryvendaPagamento = new Repository<vendaPagamento>(context);
        }

        public List<vendaPagamento> Filtrar(vendaPagamento vendaPagamento)
        {
            return repositoryvendaPagamento.ObterPorFiltros(b => (
                (vendaPagamento.ID == Guid.Empty || b.ID == vendaPagamento.ID) &&
                (vendaPagamento.vendaID == Guid.Empty || b.vendaID == vendaPagamento.vendaID) &&
                (vendaPagamento.formaPagamentoID == Guid.Empty || b.formaPagamentoID == vendaPagamento.formaPagamentoID) &&
                (vendaPagamento.empresaID == Guid.Empty || b.empresaID == vendaPagamento.empresaID)
                )).ToList();
        }

    }
}
