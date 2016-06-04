using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class clienteEndereco : SimpleX.Model.clienteEnderecoCore
    {

        public virtual cliente cliente { get; set; }
        public cidade cidade { get; set; }
        public empresa empresa { get; set; }
        public estado estado { get; set; }
        public pais pais { get; set; }
 
    }
}
