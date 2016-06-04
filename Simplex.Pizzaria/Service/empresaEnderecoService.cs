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

    public class empresaEnderecoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<empresaEndereco> repositoryempresaEndereco;

        public empresaEnderecoService()
        {
            context = new ContextPizzaria();
            repositoryempresaEndereco = new Repository<empresaEndereco>(context);
        }
        
        public List<empresaEndereco> Filtrar(empresaEndereco empresaEndereco)
        {
            return repositoryempresaEndereco.ObterPorFiltros(b => (
                (empresaEndereco.ID == Guid.Empty || b.ID == empresaEndereco.ID) &&
                (empresaEndereco.logradouro == null || b.logradouro.ToUpper().Contains(empresaEndereco.logradouro)) &&
                (empresaEndereco.numero == null || b.numero.ToUpper().Contains(empresaEndereco.numero)) &&
                (empresaEndereco.complemento == null || b.complemento.ToUpper().Contains(empresaEndereco.complemento)) &&
                (empresaEndereco.bairro == null || b.bairro.ToUpper().Contains(empresaEndereco.bairro)) &&
                (empresaEndereco.CEP == null || b.CEP.ToUpper().Contains(empresaEndereco.CEP)) &&
                (empresaEndereco.cidadeID == Guid.Empty || b.cidadeID == empresaEndereco.cidadeID) &&
                (empresaEndereco.estadoID == Guid.Empty || b.estadoID == empresaEndereco.estadoID) &&
                (empresaEndereco.paisID == Guid.Empty || b.paisID == empresaEndereco.paisID) &&
                (empresaEndereco.empresaID == Guid.Empty || b.empresaID == empresaEndereco.empresaID)
                )).ToList();
        }

    }
}
