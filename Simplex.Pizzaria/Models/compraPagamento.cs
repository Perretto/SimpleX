using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class compraPagamento : SimpleX.Model.compraPagamentoCore
    {
        public formaPagamento formaPagamento { get; set; }
        public empresa empresa { get; set; }
        public compra compra { get; set; }
    }
}
