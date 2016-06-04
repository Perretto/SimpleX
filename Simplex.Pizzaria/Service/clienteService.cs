using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using SimpleX.ModelCore;
using Simplex.Pizzaria.Repository;
using SimpleX.Model;
using System.Data.Entity;
using Simplex.Pizzaria.Context;
using SimpleX.ModelCore.Message;

namespace Simplex.Pizzaria.Service
{

    public class clienteService <T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<cliente> repositoryCliente;

        public clienteService()
        {
            context = new ContextPizzaria();
            repositoryCliente = new Repository<cliente>(context);
        }
        
                
        public List<cliente> Filtrar(cliente cliente)
        {
            return repositoryCliente.ObterPorFiltros(b => (
                (cliente.ID == Guid.Empty || b.ID == cliente.ID) &&
                (cliente.razaoSocial == null || b.razaoSocial.ToUpper().Contains(cliente.razaoSocial)) &&
                (cliente.nomeFantasia == null || b.nomeFantasia.ToUpper().Contains(cliente.nomeFantasia)) &&
                (cliente.codigo == null || b.codigo == cliente.codigo) &&
                (cliente.CNPJ == null || b.CNPJ.ToUpper().Contains(cliente.CNPJ)) &&
                (cliente.CPF == null || b.CPF.ToUpper().Contains(cliente.CPF)) &&
                (cliente.RG == null || b.RG.ToUpper().Contains(cliente.RG)) &&
                (cliente.IE == null || b.IE.ToUpper().Contains(cliente.IE)) &&
                (cliente.IM == null || b.IM.ToUpper().Contains(cliente.IM)) &&
                (cliente.suframa == null || b.suframa.ToUpper().Contains(cliente.suframa)) &&
                (cliente.CNAEID == Guid.Empty || b.CNAEID == cliente.CNAEID) &&                
                (cliente.empresaID == Guid.Empty || b.empresaID == cliente.empresaID)
                )).ToList();
        }

    }
}
