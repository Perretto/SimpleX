using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class URA : SimpleX.Model.URACore
    {

        public statusURA statusURA { get; set; }

        public empresa empresa { get; set; }

    }
}
