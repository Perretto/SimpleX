using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class venda
    {
        public Guid ID { get; set; }
        public int numeroPedido { get; set; }
        public Guid clienteID { get; set; }
        public cliente cliente { get; set; }
        public Decimal valorTotal { get; set; }
        public Guid vendaStatusID { get; set; }
        public vendaStatus vendaStatus { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
        public List<vendaProduto> vendaProdutos { get; set; }
    }
}
