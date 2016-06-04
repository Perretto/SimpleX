using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class fornecedor : SimpleX.Model.fornecedorCore
    {
        public virtual List<fornecedorEndereco> fornecedoresEnderecos { get; set; }
        public virtual List<fornecedorContato> fornecedoresContatos { get; set; }
        public empresa empresa { get; set; }
        public CNAE CNAE { get; set; }

    }
}
