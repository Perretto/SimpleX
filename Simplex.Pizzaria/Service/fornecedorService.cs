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

    public class fornecedorService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<fornecedor> repositoryfornecedor;

        public fornecedorService()
        {
            context = new ContextPizzaria();
            repositoryfornecedor = new Repository<fornecedor>(context);
        }


        public List<fornecedor> Filtrar(fornecedor fornecedor)
        {
            return repositoryfornecedor.ObterPorFiltros(b => (
                (fornecedor.ID == Guid.Empty || b.ID == fornecedor.ID) &&
                (fornecedor.codigo == null || b.codigo.ToUpper().Contains(fornecedor.codigo)) &&
                (fornecedor.razaoSocial == null || b.razaoSocial.ToUpper().Contains(fornecedor.razaoSocial)) &&
                (fornecedor.nomeFantasia == null || b.nomeFantasia.ToUpper().Contains(fornecedor.nomeFantasia)) &&
                (fornecedor.CNPJ == null || b.CNPJ.ToUpper().Contains(fornecedor.CNPJ)) &&
                (fornecedor.CPF == null || b.CPF.ToUpper().Contains(fornecedor.CPF)) &&
                (fornecedor.RG == null || b.RG.ToUpper().Contains(fornecedor.RG)) &&
                (fornecedor.IE == null || b.IE.ToUpper().Contains(fornecedor.IE)) &&
                (fornecedor.IM == null || b.IM.ToUpper().Contains(fornecedor.IM)) &&
                (fornecedor.CNAEID == Guid.Empty || b.CNAEID == fornecedor.CNAEID) &&
                (fornecedor.empresaID == Guid.Empty || b.empresaID == fornecedor.empresaID)
                )).ToList();
        }

    }
}
