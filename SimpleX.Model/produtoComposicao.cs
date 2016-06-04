using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class produtoComposicao
    {
        [Key]
        public Guid ID { get; set; }
        public Guid produtoOrigemID { get; set; }
        public Guid produtoDestinoID { get; set; }
        public Decimal quantidade { get; set; }
        public Guid empresaID { get; set; }
    }
}
