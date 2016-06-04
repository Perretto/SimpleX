using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SimpleX.Model
{
    public class produto
    {
        [Key]
        public Guid ID { get; set; }
        public string codigo { get; set; }
        public string nome { get; set; }
        public Guid produtoCategoriaID { get; set; }
        public produtoCategoria produtoCategoria { get; set; }
        public Decimal valorProduto { get; set; }
        public Guid produtoTipoID { get; set; }
        public produtoTipo produtoTipo { get; set; }
        public Guid empresaID { get; set; }
        public empresa empresa { get; set; }

    }
}
