using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class compraPagamento
    {
        [Key]
        public Guid ID { get; set; }
        public Guid compraID { get; set; }
        public compra compra { get; set; }
        public Guid formaPagamentoID { get; set; }
        public Guid empresaID { get; set; }
    }
}
