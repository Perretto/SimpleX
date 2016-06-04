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

    public class compraPagamentoService<T> : pizzariaService<T> where T : class

    {
        private ContextPizzaria context;
        private Repository<compraPagamento> repositorycompraPagamento;

        public compraPagamentoService()
        {
            context = new ContextPizzaria();
            repositorycompraPagamento = new Repository<compraPagamento>(context);
        }
        
        public List<compraPagamento> Filtrar(compraPagamento compraPagamento)
        {
            return repositorycompraPagamento.ObterPorFiltros(b => (
                (compraPagamento.ID == Guid.Empty || b.ID == compraPagamento.ID) &&
                (compraPagamento.compraID == Guid.Empty || b.compraID == compraPagamento.compraID) &&
                (compraPagamento.formaPagamentoID == Guid.Empty || b.formaPagamentoID == compraPagamento.formaPagamentoID) &&
                (compraPagamento.empresaID == Guid.Empty || b.empresaID == compraPagamento.empresaID)
                )).ToList();
        }

    }
}
