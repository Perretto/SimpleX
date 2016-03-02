using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class clienteContato
    {
        public Guid ID { get; set; }
        public string nomeContato { get; set; }
        public string telefoneContato { get; set; }
        public string emailContato { get; set; }
        public Guid clienteID { get; set; }
        public virtual cliente cliente { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
 
    }
}
