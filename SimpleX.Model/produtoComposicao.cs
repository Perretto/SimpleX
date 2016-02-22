using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class produtoComposicao
    {
        public Guid ID { get; set; }
        public Guid produtoOrigemID { get; set; }
        public produto produtoOrigem { get; set; }
        public Guid produtoDestinoID { get; set; }
        public produto produtoDestino { get; set; }
        public Decimal quantidade { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
