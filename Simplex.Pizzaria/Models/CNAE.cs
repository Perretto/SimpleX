using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Simplex.Pizzaria.Models
{
    public class CNAE : SimpleX.Model.CNAECore
    {
        public List<CNAE> ListaCNAEs()
        {

            return new List<CNAE>

            {

                new CNAE { ID = Guid.NewGuid(), nome = ""},

                new CNAE { ID = Guid.NewGuid(), nome = ""},

                new CNAE { ID = Guid.NewGuid(), nome = ""}

            };

        }


    }
}
