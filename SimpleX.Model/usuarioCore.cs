using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("usuario")] 
    public class usuarioCore
    {
        [Key]
        public Guid ID { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public Guid empresaID { get; set; }
    }
}
