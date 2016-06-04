using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("compraproduto")] 
    public class compraProdutoCore
    {
        [Key]
        public Guid ID { get; set; }
        public Guid compraID { get; set; }
        public Guid produtoID { get; set; }
        public Decimal valorUnitario { get; set; }
        public Decimal quantidade { get; set; }
        public Decimal valorTotal { get; set; }
        public Guid empresaID { get; set; }

    }
}
