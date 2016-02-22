using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class fornecedorContato
    {
        public Guid ID { get; set; }
        public string nomeContato { get; set; }
        public string telefoneContato { get; set; }
        public string emailContato { get; set; }
        public Guid fornecedorID { get; set; }
        public fornecedor fornecedor { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
