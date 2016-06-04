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

    public class empresaService<T> : pizzariaService<T> where T : class
    {
        private ContextPizzaria context;
        private Repository<empresa> repositoryEmpresa;

        public empresaService()
        {
            context = new ContextPizzaria();
            repositoryEmpresa = new Repository<empresa>(context);
        }
        
        public List<empresa> Filtrar(empresa empresa)
        {
            return repositoryEmpresa.ObterPorFiltros(b => (
                (empresa.ID == Guid.Empty || b.ID == empresa.ID) &&
                (empresa.razaoSocial == null || b.razaoSocial.ToUpper().Contains(empresa.razaoSocial)) &&
                (empresa.nomeFantasia == null || b.nomeFantasia.ToUpper().Contains(empresa.nomeFantasia)) &&
                (empresa.CNPJ == null || b.CNPJ.ToUpper().Contains(empresa.CNPJ)) &&
                (empresa.CPF == null || b.CPF.ToUpper().Contains(empresa.CPF)) &&
                (empresa.RG == null || b.RG.ToUpper().Contains(empresa.RG)) &&
                (empresa.IE == null || b.IE.ToUpper().Contains(empresa.IE)) &&
                (empresa.IM == null || b.IM.ToUpper().Contains(empresa.IM)) &&
                (empresa.numeroWhatsApp == null || b.numeroWhatsApp == empresa.numeroWhatsApp) &&
                (empresa.nomeWhatsApp == null || b.nomeWhatsApp == empresa.nomeWhatsApp) &&
                (empresa.senhaWhatsApp == null || b.senhaWhatsApp == empresa.senhaWhatsApp) &&
                (empresa.CNAEID == Guid.Empty || b.CNAEID == empresa.CNAEID)
                )).ToList();
        }

    }
}
