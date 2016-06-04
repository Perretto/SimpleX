using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class empresaEndereco : SimpleX.Model.empresaEnderecoCore
    {
        public cidade cidade { get; set; }
        public pais pais { get; set; }
        public estado estado { get; set; }
        public empresa empresa { get; set; }

    }
}
