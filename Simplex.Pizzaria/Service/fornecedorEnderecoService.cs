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

    public class fornecedorEnderecoService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<fornecedorEndereco> repositoryFornecedorEndereco;

        public fornecedorEnderecoService()
        {
            context = new ContextPizzaria();
            repositoryFornecedorEndereco = new Repository<fornecedorEndereco>(context);
        }


        public List<fornecedorEndereco> Filtrar(fornecedorEndereco fornecedorEndereco)
        {
            return repositoryFornecedorEndereco.ObterPorFiltros(b => (
                (fornecedorEndereco.ID == Guid.Empty || b.ID == fornecedorEndereco.ID) &&
                (fornecedorEndereco.logradouro == null || b.logradouro.ToUpper().Contains(fornecedorEndereco.logradouro)) &&
                (fornecedorEndereco.numero == null || b.numero.ToUpper().Contains(fornecedorEndereco.numero)) &&
                (fornecedorEndereco.complemento == null || b.complemento.ToUpper().Contains(fornecedorEndereco.complemento)) &&
                (fornecedorEndereco.bairro == null || b.bairro.ToUpper().Contains(fornecedorEndereco.bairro)) &&
                (fornecedorEndereco.CEP == null || b.CEP.ToUpper().Contains(fornecedorEndereco.CEP)) &&

                (fornecedorEndereco.cidadeID == Guid.Empty || b.cidadeID == fornecedorEndereco.cidadeID) &&
                (fornecedorEndereco.estadoID == Guid.Empty || b.estadoID == fornecedorEndereco.estadoID) &&
                (fornecedorEndereco.paisID == Guid.Empty || b.paisID == fornecedorEndereco.paisID) &&
                (fornecedorEndereco.fornecedorID == Guid.Empty || b.fornecedorID == fornecedorEndereco.fornecedorID) &&
                (fornecedorEndereco.empresaID == Guid.Empty || b.empresaID == fornecedorEndereco.empresaID)

                )).ToList();
        }

    }
}
