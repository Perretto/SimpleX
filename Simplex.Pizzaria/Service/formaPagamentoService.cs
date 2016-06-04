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

    public class formaPagamentoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;

        private Repository<formaPagamento> repositoryformaPagamento;

        public formaPagamentoService()
        {
            context = new ContextPizzaria();
            repositoryformaPagamento = new Repository<formaPagamento>(context);
        }
                
        public List<formaPagamento> Filtrar(formaPagamento formaPagamento)
        {
            return repositoryformaPagamento.ObterPorFiltros(b => (
                (formaPagamento.ID == Guid.Empty || b.ID == formaPagamento.ID) &&
                (formaPagamento.nome == null || b.nome.ToUpper().Contains(formaPagamento.nome)) &&
                (formaPagamento.empresaID == Guid.Empty || b.empresaID == formaPagamento.empresaID)
                )).ToList();
        }

    }
}
