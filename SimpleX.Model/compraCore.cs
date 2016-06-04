using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("compra")] 
    public class compraCore
    {
        [Key]
        public Guid ID { get; set; }
        public int numeroPedido { get; set; }
        public Decimal valorTotal { get; set; }
        public Guid compraStatusID { get; set; }
        public Guid empresaID { get; set; }
    }
}
