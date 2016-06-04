using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class clienteEndereco
    {
        [Key]
        public Guid ID { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string CEP { get; set; }
        public Guid cidadeID { get; set; }
        public Guid estadoID { get; set; }
        public Guid paisID { get; set; }
        public Guid empresaID { get; set; }
        public Guid clienteID { get; set; }


 
    }
}
