using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("produtocomposicao")] 
    public class produtoComposicaoCore
    {
        [Key]
        public Guid ID { get; set; }
        public Guid produtoOrigemID { get; set; }
        public Guid produtoDestinoID { get; set; }
        public Decimal quantidade { get; set; }
        public Guid empresaID { get; set; }
    }
}
