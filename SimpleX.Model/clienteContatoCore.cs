using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("clientecontato")] 
    public class clienteContatoCore
    {
        [Key]
        public Guid ID { get; set; }
        public string nomeContato { get; set; }
        public string telefoneContato { get; set; }
        public string emailContato { get; set; }
        public Guid clienteID { get; set; }
        public Guid empresaID { get; set; }
 
    }
}
