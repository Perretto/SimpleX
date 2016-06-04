using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class fornecedorEndereco : SimpleX.Model.fornecedorEnderecoCore
    {
        public cidade cidade { get; set; }
        public estado estado { get; set; }
        public pais pais { get; set; }
        public empresa empresa { get; set; }
        public fornecedor fornecedor { get; set; }

    }
}
