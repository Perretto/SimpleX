using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class cliente : SimpleX.Model.clienteCore
    {

        public virtual List<clienteEndereco> clientesEnderecos { get; set; }
        public virtual List<clienteContato> clientesContatos { get; set; }
        public empresa empresa { get; set; }
        public CNAE CNAE { get; set; }


    }
}
