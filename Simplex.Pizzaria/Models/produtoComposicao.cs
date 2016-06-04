using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class produtoComposicao : SimpleX.Model.produtoComposicao
    {
        public produto produtoOrigem { get; set; }
        public produto produtoDestino { get; set; }
        public empresa empresa { get; set; }
    }
}
