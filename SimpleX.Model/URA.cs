using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class URA
    {
        [Key]
        public Guid ID { get; set; }
        public string texto { get; set; }
        public string nivel { get; set; }
        public Guid statusURAID { get; set; }
        public Guid empresaID { get; set; }
       
    }
}
