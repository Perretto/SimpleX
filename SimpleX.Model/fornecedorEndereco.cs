using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class fornecedorEndereco
    {
        [Key]
        public Guid ID { get; set; }
        public string logradouro { get; set; }
        public string numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string CEP { get; set; }
        public Guid cidadeID { get; set; }
        public cidade cidade { get; set; }
        public Guid estadoID { get; set; }
        public estado estado { get; set; }
        public Guid paisID { get; set; }
        public pais pais { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }
        public Guid fornecedorID { get; set; }
        public fornecedor fornecedor { get; set; }
    }
}
