using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("vendapagamento")] 
    public class vendaPagamentoCore
    {
        [Key]
        public Guid ID { get; set; }
        public Guid vendaID { get; set; }
        public Guid formaPagamentoID { get; set; }
        public Guid empresaID { get; set; }
    }
}
