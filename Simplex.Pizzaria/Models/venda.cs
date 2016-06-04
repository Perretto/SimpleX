using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class venda : SimpleX.Model.vendaCore
    {
        public empresa empresa { get; set; }
        public List<vendaProduto> vendaProdutos { get; set; }
        public vendaStatus vendaStatus { get; set; }
        public cliente cliente { get; set; }


    }
}
