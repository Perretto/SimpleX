using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class compraProduto : SimpleX.Model.compraProdutoCore
    {
        public compra compra { get; set; }
        public produto produto { get; set; }
        public empresa empresa { get; set; }
        

    }
}
