using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class compra : SimpleX.Model.compra
    {
        public compraStatus compraStatus { get; set; }
        public empresa empresa { get; set; }
    }
}
