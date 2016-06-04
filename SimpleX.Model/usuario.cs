using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class usuario
    {
        [Key]
        public Guid ID { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
    }
}
