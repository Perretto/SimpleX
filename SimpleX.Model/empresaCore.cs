using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleX.Model
{
    [Table("empresa")] 
    public class empresaCore
    {
        

        [Key]
        public Guid ID { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public Guid CNAEID { get; set; }
        public string numeroWhatsApp { get; set; }
        public string nomeWhatsApp { get; set; }
        public string senhaWhatsApp { get; set; }
    }
}
