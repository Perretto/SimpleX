using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.Model
{
    public class systemMessage
    {
        public Guid ID { get; set; } 
        public string type { get; set; }
        public string internalNumber { get; set; }
        public string externalNumber { get; set; }
        public string description { get; set; }
        public bool success { get; set; }
    }
}
