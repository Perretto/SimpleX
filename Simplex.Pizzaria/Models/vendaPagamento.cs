using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class vendaPagamento : SimpleX.Model.vendaPagamentoCore
    {
        public empresa empresa { get; set; }
        public formaPagamento formaPagamento { get; set; }
        public venda venda { get; set; }


    }
}
