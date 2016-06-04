using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class statusURA
    {
        [Key]
        public Guid ID { get; set; }
        public string texto { get; set; } // Exemplo: (NENHUM, ATENDENTE, PROXIMO)
        public Guid empresaID { get; set; }
    }
}
