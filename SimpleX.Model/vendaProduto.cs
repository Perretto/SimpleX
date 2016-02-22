using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class vendaProduto
    {
        public Guid ID { get; set; }
        public Guid vendaID { get; set; }
        public venda venda { get; set; }
        public Guid produtoID { get; set; }
        public produto produto { get; set; }
        public Decimal valorUnitario { get; set; }
        public Decimal quantidade { get; set; }
        public Decimal valorTotal { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
