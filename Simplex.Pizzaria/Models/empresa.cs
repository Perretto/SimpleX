﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class empresa : SimpleX.Model.empresaCore
    {
        public CNAE CNAE { get; set; }

    }
}
