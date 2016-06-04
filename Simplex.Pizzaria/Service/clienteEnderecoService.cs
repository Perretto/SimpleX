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

    public class clienteEnderecoService<T> : pizzariaService<T> where T : class

    {
        private ContextPizzaria context;

        private Repository<clienteEndereco> repositoryclienteEndereco;

        public clienteEnderecoService()
        {
            context = new ContextPizzaria();
            repositoryclienteEndereco = new Repository<clienteEndereco>(context);
        }
                
        public List<clienteEndereco> Filtrar(clienteEndereco clienteEndereco)
        {
            return repositoryclienteEndereco.ObterPorFiltros(b => (
                (clienteEndereco.ID == Guid.Empty || b.ID == clienteEndereco.ID) &&
                (clienteEndereco.logradouro == null || b.logradouro.ToUpper().Contains(clienteEndereco.logradouro)) &&
                (clienteEndereco.numero == null || b.numero.ToUpper().Contains(clienteEndereco.numero)) &&
                (clienteEndereco.complemento == null || b.complemento.ToUpper().Contains(clienteEndereco.complemento)) &&
                (clienteEndereco.bairro == null || b.bairro.ToUpper().Contains(clienteEndereco.bairro)) &&
                (clienteEndereco.CEP == null || b.CEP.ToUpper().Contains(clienteEndereco.CEP)) &&
                (clienteEndereco.cidadeID == Guid.Empty || b.cidadeID == clienteEndereco.cidadeID) &&
                (clienteEndereco.estadoID == Guid.Empty || b.estadoID == clienteEndereco.estadoID) &&
                (clienteEndereco.paisID == Guid.Empty || b.paisID == clienteEndereco.paisID) &&
                (clienteEndereco.empresaID == Guid.Empty || b.empresaID == clienteEndereco.empresaID) &&
                (clienteEndereco.clienteID == Guid.Empty || b.clienteID == clienteEndereco.clienteID)

                )).ToList();
        }

    }
}
