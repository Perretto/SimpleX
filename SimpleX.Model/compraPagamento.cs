using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class compraPagamento
    {
        public Guid ID { get; set; }
        public Guid compraID { get; set; }
        public compra compra { get; set; }
        public Guid formaPagamentoID { get; set; }
        public formaPagamento formaPagamento { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
