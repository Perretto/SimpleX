using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class produtoCategoria
    {
        public Guid ID { get; set; }
        public string nome { get; set; }
        public Guid empresaID { get; set; }
    }
}
