using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SimpleX.Model
{
    [Table("systemmessage")] 
    public class systemMessageCore
    {
        [Key]
        public Guid ID { get; set; } 
        public string type { get; set; }
        public string internalNumber { get; set; }
        public string externalNumber { get; set; }
        public string description { get; set; }
        [NotMapped]
        public bool success { get; set; }
    }
}
