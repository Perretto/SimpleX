﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class clienteContato : SimpleX.Model.clienteContatoCore
    {
        public virtual cliente cliente { get; set; }
        public empresa empresa { get; set; }
 
    }
}
