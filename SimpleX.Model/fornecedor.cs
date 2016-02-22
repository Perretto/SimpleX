using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class fornecedor
    {
        public Guid ID { get; set; }
        public string codigo { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public Guid CNAEID { get; set; }
        public CNAE CNAE { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
