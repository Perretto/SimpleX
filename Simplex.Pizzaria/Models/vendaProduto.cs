using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simplex.Pizzaria.Models
{
    public class vendaProduto : SimpleX.Model.vendaProduto
    {
        public Guid subProdutoID { get; set; }
        public empresa empresa { get; set; }
        public produto produto { get; set; }
        public venda venda { get; set; }


    }
}