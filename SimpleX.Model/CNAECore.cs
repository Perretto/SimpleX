using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("cnae")] 
    public class CNAECore
    {
        [Key]
        public Guid ID { get; set; }
        public string nome { get; set; }
        public string codigo { get; set; }

        
    }
}
