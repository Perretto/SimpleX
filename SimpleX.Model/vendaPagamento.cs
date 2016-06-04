using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class vendaPagamento
    {
        [Key]
        public Guid ID { get; set; }
        public Guid vendaID { get; set; }
        public venda venda { get; set; }
        public Guid formaPagamentoID { get; set; }
        public formaPagamento formaPagamento { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
