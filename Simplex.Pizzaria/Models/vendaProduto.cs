using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simplex.Pizzaria.Models
{
    public class vendaProduto : SimpleX.Model.vendaProduto
    {
        public Guid subProdutoID { get; set; }
    }
}