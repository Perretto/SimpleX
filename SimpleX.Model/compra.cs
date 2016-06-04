using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class compra
    {
        [Key]
        public Guid ID { get; set; }
        public int numeroPedido { get; set; }
        public Decimal valorTotal { get; set; }
        public Guid compraStatusID { get; set; }
        public compraStatus compraStatus { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
