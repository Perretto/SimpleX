using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class fornecedorContato : SimpleX.Model.fornecedorContatoCore
    {
        public empresa empresa { get; set; }
        public fornecedor fornecedor { get; set; }

    }
}
