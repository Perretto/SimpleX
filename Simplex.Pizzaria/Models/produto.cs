using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class produto : SimpleX.Model.produto
    {
        public empresa empresa { get; set; }
        public produtoCategoria produtoCategoria { get; set; }
        public produtoTipo produtoTipo { get; set; }


    }
}
